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
    public class StateController : BaseController
    {
        #region Fields
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly INotyfService notyf;
        #endregion

        #region Constructors
        public StateController(IUnitOfWork unitOfWork,IMapper mapper, INotyfService notyf)
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
                            notyf.Success(Entity.State + Constants.Space + Constants.InsertedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Update:
                        {
                            notyf.Success(Entity.State + Constants.Space + Constants.UpdatedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Delete:
                        {
                            notyf.Success(Entity.State + Constants.Space + Constants.DeletedSuccesfully, 10);
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
            List<StateListingDTO> lst = new List<StateListingDTO>();
            //Stored Procedure Call
            var parameter = new DynamicParameters();
            parameter.Add("@StateID", 0);
            parameter.Add("@Enabled", true);
            var allObj = unitOfWork.storedProcedureRepository.List<StateListingDTO>(Constants.usp_GetStatesWithCountry, parameter);
            foreach (var item in allObj)
            {
                lst.Add(mapper.Map<StateListingDTO>(item));
            }
            return View(lst);
        } 

        [HttpGet]
        public IActionResult Upsert(int? id)
        {            
            StateCrudDTO model = new StateCrudDTO();
            model.Countries = unitOfWork.countryRepository.GetAll().Select(i => new SelectListItem
            {
                Text = i.CountryName,
                Value = i.CountryId.ToString()
            });
            if (id == null)
            {
                //for create
                return View(model);
            }
            else
            {
                ////for edit
                //Stored Procedure Call
                var parameter = new DynamicParameters();
                parameter.Add("@StateID", id.GetValueOrDefault());
                parameter.Add("@Enabled", true);
                model = unitOfWork.storedProcedureRepository.OneRecord<StateCrudDTO>(Constants.usp_GetStatesWithCountry, parameter);                                          
                if (model == null)
                {
                    return NotFound();
                }                
                model.Countries = unitOfWork.countryRepository.GetAll().Select(i => new SelectListItem
                {
                    Text = i.CountryName,
                    Value = i.CountryId.ToString()
                });
                return View(model);
            }            
        }

        [HttpPost]
        public IActionResult Upsert(StateCrudDTO model)
        {
            model.Countries = unitOfWork.countryRepository.GetAll().Select(i => new SelectListItem
            {
                Text = i.CountryName,
                Value = i.CountryId.ToString()
            });
            if (ModelState.IsValid)
            {
                model.Enabled = true;
                State objState = mapper.Map<State>(model);
                if(model.StateId == 0)
                {
                    unitOfWork.stateRepository.Add(objState);
                    TempData["ShowMessage"] = CrudOperationType.Insert;
                }
                else
                {
                    unitOfWork.stateRepository.Update(objState);
                    TempData["ShowMessage"] = CrudOperationType.Update;
                }
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }        
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            State objState = unitOfWork.stateRepository.Get(id);
            if (objState == null)
            {
                notyf.Error("State Not Found,Error while deleting", 10);
                return Json(new { success = false, message = "Error while deleting" });
            }
            unitOfWork.stateRepository.Remove(mapper.Map<State>(objState));
            unitOfWork.SaveChanges();
            TempData["ShowMessage"] = CrudOperationType.Delete;
            notyf.Information("State Deleted Successfully", 10);            
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
