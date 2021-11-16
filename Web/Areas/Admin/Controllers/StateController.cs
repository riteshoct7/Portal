using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Web.Areas.Admin.Models.Dtos;

namespace Web.Areas.Admin.Controllers
{
    public class StateController : BaseController
    {
        #region Fields
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        #endregion

        #region Constructors
        public StateController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            IEnumerable<State> lstState = unitOfWork.stateRepository.GetAll();            
            List<StateListingDTO> lst = new List<StateListingDTO>();
            foreach (var item in lstState)
            {
                lst.Add(mapper.Map<StateListingDTO>(item));
            }
            return View(lst);

            
        } 
        #endregion
    }
}
