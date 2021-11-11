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
                parameter.Add("@CountryID",0);
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
                return View(lst);
            }
        }
        #endregion
    }
    
}
