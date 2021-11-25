using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Common;
using Dapper;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Interfaces;
using Web.Areas.Admin.Models.Dtos;
using static Common.Constants;

namespace Web.Areas.Admin.Controllers
{
    public class CityController : BaseController
    {
        #region Fields
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly INotyfService notyf;
        #endregion

        #region Constructors
        public CityController(IUnitOfWork unitOfWork,IMapper mapper, INotyfService notyf)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.notyf = notyf;
        }
        #endregion

        #region Methods
        public void ShowMessage()
        {
            if (TempData.ContainsKey("ShowMessage"))
            {
                CrudOperationType tempDataShowMessage = (CrudOperationType)TempData["ShowMessage"]; // returns "Bill" 
                switch (tempDataShowMessage)
                {
                    case CrudOperationType.Insert:
                        {
                            notyf.Success(Entity.City + Constants.Space + Constants.InsertedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Update:
                        {
                            notyf.Success(Entity.City + Constants.Space + Constants.UpdatedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Delete:
                        {
                            notyf.Success(Entity.City + Constants.Space + Constants.DeletedSuccesfully, 10);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }

        }
        public IActionResult Index()
        {
            ShowMessage();
            List<CityListingDTO> lst = new List<CityListingDTO>();
            //Stored Procedure Call
            var parameter = new DynamicParameters();
            parameter.Add("@CityId", 0);
            parameter.Add("@Enabled", true);
            var allObj = unitOfWork.storedProcedureRepository.List<CityListingDTO>(Constants.usp_GetCityWithStateCountry, parameter);
            foreach (var item in allObj)
            {
                lst.Add(mapper.Map<CityListingDTO>(item));
            }
            return View(lst);
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {

            CityCrudDTO model = new CityCrudDTO();
            model.Countries = unitOfWork.countryRepository.GetAll().Select(i => new SelectListItem
            {
                Text = i.CountryName,
                Value = i.CountryId.ToString()
            });
            model.States = unitOfWork.stateRepository.GetAll().Select(i => new SelectListItem
            {
                Text = i.StateName,
                Value = i.StateId.ToString()
            });
            if (id == null)
            {
                //for create
                return View(model);
            }
            else
            {
                ////for edit
                var parameter = new DynamicParameters();
                parameter.Add("@CityId", id.GetValueOrDefault());
                parameter.Add("@Enabled", true);
                model = unitOfWork.storedProcedureRepository.OneRecord <CityCrudDTO>(Constants.usp_GetCityWithStateCountry, parameter);               
                if (model == null)
                {
                    return NotFound();
                }                
                model.Countries = unitOfWork.countryRepository.GetAll().Select(i => new SelectListItem
                {
                    Text = i.CountryName,
                    Value = i.CountryId.ToString()
                });
                model.States = unitOfWork.stateRepository.GetAll().Select(i => new SelectListItem
                {
                    Text = i.StateName,
                    Value = i.StateId.ToString()
                });
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Upsert(CityCrudDTO model)
        {
            model.Countries = unitOfWork.countryRepository.GetAll().Select(i => new SelectListItem
            {
                Text = i.CountryName,
                Value = i.CountryId.ToString()
            });
            model.States = unitOfWork.stateRepository.GetAll().Select(i => new SelectListItem
            {
                Text = i.StateName,
                Value = i.StateId.ToString()
            });
            if (ModelState.IsValid)
            {
                model.Enabled = true;
                City objCity = mapper.Map<City>(model);
                if (model.CityId == 0)
                {
                    unitOfWork.cityRepository.Add(objCity);
                    TempData["ShowMessage"] = CrudOperationType.Insert;
                }
                else
                {
                    unitOfWork.cityRepository.Update(objCity);
                    TempData["ShowMessage"] = CrudOperationType.Update;
                }
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            City objCity = unitOfWork.cityRepository.Get(id);
            if (objCity == null)
            {
                notyf.Error("City Not Found,Error while deleting", 10);
                return Json(new { success = false, message = "Error while deleting" });
            }
            unitOfWork.cityRepository.Remove(mapper.Map<City>(objCity));
            unitOfWork.SaveChanges();
            TempData["ShowMessage"] = CrudOperationType.Delete;
            notyf.Information("City Deleted Successfully", 10);            
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
