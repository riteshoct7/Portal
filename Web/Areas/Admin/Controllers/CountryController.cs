using AutoMapper;
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
                IEnumerable<Country> lstcountry = unitOfWork.countryRepository.GetAll();

                List<CountryListingDTO> lst = new List<CountryListingDTO>();
                foreach (var item in lstcountry)
                {
                    lst.Add(mapper.Map<CountryListingDTO>(item));
                }
                return View(lst);
            }
        }
        #endregion
    }
    
}
