using AutoMapper;
using Common;
using Dapper;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Web.Areas.Admin.Models.Dtos;

namespace Web.Areas.Admin.Controllers
{
    public class CountryController : BaseController
    {
        #region Fields

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        #endregion

        #region Constructors
        public CountryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        #endregion

        #region Methods

        public IActionResult Index()
        {
            {
                
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
        }
        #endregion
    }
    
}
