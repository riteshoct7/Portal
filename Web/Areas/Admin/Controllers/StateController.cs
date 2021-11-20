using AutoMapper;
using Common;
using Dapper;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                State objState = unitOfWork.stateRepository.Get(id.GetValueOrDefault());
                if (objState == null)
                {
                    return NotFound();
                }
                model = mapper.Map<StateCrudDTO>(objState);
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
                }
                else
                {
                    unitOfWork.stateRepository.Update(objState);
                }
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
        
            return View(model);
        }

        #endregion
    }
}
