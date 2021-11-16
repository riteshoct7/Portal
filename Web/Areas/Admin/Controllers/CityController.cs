using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Web.Areas.Admin.Models.Dtos;

namespace Web.Areas.Admin.Controllers
{
    public class CityController : BaseController
    {
        #region Fields
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        #endregion

        #region Constructors
        public CityController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            IEnumerable<City> lstCity = unitOfWork.cityRepository.GetAll();
            List<CityListingDTO> lst = new List<CityListingDTO>();
            foreach (var item in lstCity)
            {                
              lst.Add(mapper.Map<CityListingDTO>(item));
            }
            return View(lst);
        } 
        #endregion
    }
}
