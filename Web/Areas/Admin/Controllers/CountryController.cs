using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Common;
using Dapper;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Web.Areas.Admin.Models.Dtos;
using static Common.Constants;

namespace Web.Areas.Admin.Controllers
{
    public class CountryController : BaseController
    {
        #region Fields

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly INotyfService notyf;

        #endregion

        #region Constructors
        public CountryController(IUnitOfWork unitOfWork, IMapper mapper, INotyfService notyf)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.notyf = notyf;
        }
        #endregion

        #region Methods

        public void ShowMessage ()
        {
            if (TempData.ContainsKey("ShowMessage"))
            {
                CrudOperationType tempDataShowMessage = (CrudOperationType)TempData["ShowMessage"]; // returns "Bill" 
                switch (tempDataShowMessage)
                {
                    case CrudOperationType.Insert:
                        {
                            notyf.Success(Entity.Country + Constants.Space + Constants.InsertedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Update:
                        {
                            notyf.Success(Entity.Country + Constants.Space + Constants.UpdatedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Delete:
                        {
                            notyf.Success(Entity.Country + Constants.Space + Constants.DeletedSuccesfully, 10);
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
                List<CountryListingDTO> lst = new List<CountryListingDTO>();
                //Stored Procedure Call
                var parameter = new DynamicParameters();
                parameter.Add("@CountryID", 0);
                parameter.Add("@Enabled", true);
                var allObj = unitOfWork.storedProcedureRepository.List<Country>(Constants.usp_SelectCountry, parameter);
                foreach (var item in allObj)
                {
                    lst.Add(mapper.Map<CountryListingDTO>(item));
                }

                //Linq Call
                //IEnumerable<Country> lstcountry = unitOfWork.countryRepository.GetAll();                 
                //foreach (var item in lstcountry)
                //{
                //    lst.Add(mapper.Map<CountryListingDTO>(item));
                //}



                //For deleting
                //int id = 3;                
                //var selectParameter = new DynamicParameters();
                //selectParameter.Add("@CountryID", id);
                //selectParameter.Add("@Enabled", true);
                //var objFromDB = unitOfWork.storedProcedureRepository.OneRecord<Country>(Constants.usp_SelectCountry, selectParameter);
                //if (objFromDB !=null)
                //{
                //    var deleteParameter = new DynamicParameters();
                //    deleteParameter.Add("@CountryID", id);
                //    unitOfWork.storedProcedureRepository.Execute(Constants.usp_DeleteCountry, deleteParameter);
                //}


                //For inserting
                //var insertParameter = new DynamicParameters();
                //insertParameter.Add("@CountryName", "Test");
                //insertParameter.Add("@ISDCode", "Test");
                //insertParameter.Add("@Description", "Test");
                //insertParameter.Add("@Enabled", true);
                //insertParameter.Add("@ReturnVal", 1);
                //unitOfWork.storedProcedureRepository.Execute(Constants.usp_InsertCountry, insertParameter);

                //For Updating
                //var updateParameter = new DynamicParameters();
                //int CountryId = 4;
                //updateParameter.Add("@CountryId", CountryId);
                //updateParameter.Add("@CountryName", "Test1");
                //updateParameter.Add("@ISDCode", "Test1");
                //updateParameter.Add("@Description", "Test1");
                //updateParameter.Add("@Enabled", true);                
                //unitOfWork.storedProcedureRepository.Execute(Constants.usp_UpdateCountry, updateParameter);

                return View(lst);

            
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            CountryListingDTO model = new CountryListingDTO();            
            if (id == null)
            {
                //for create
                return View(model);
            }
            else
            {
                ////for edit
                Country objCountry = unitOfWork.countryRepository.Get(id.GetValueOrDefault());
                if (objCountry == null)
                {
                    return NotFound();
                }
                model = mapper.Map<CountryListingDTO>(objCountry);                
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Upsert(CountryListingDTO model)
        {
            if (ModelState.IsValid)
            {
                model.Enabled = true;
                Country objCountry = mapper.Map<Country>(model);
                if (model.CountryId == 0)
                {
                    unitOfWork.countryRepository.Add(objCountry);
                    TempData["ShowMessage"] = CrudOperationType.Insert;
                }
                else
                {
                    unitOfWork.countryRepository.Update(objCountry);
                    TempData["ShowMessage"] = CrudOperationType.Update;
                }
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Country objCountry = unitOfWork.countryRepository.Get(id);
            if (objCountry == null)
            {
                notyf.Error("State Not Found,Error while deleting", 10);
                return Json(new { success = false, message = "Error while deleting" });
            }
            unitOfWork.countryRepository.Remove(mapper.Map<Country>(objCountry));
            unitOfWork.SaveChanges();
            notyf.Information("State Deleted Successfully", 10);            
            TempData["ShowMessage"] = CrudOperationType.Delete;
            //return RedirectToAction(nameof(Index));
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
    
}
