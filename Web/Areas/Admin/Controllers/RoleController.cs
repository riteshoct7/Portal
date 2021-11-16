using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Web.Areas.Admin.Models.Dtos;

namespace Web.Areas.Admin.Controllers
{
    public class RoleController : BaseController
    {

        #region Fields

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        #endregion

        #region Constructors

        public RoleController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager,
                RoleManager<ApplicationRole> roleManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        #endregion

        #region Methods

        [HttpGet]
        public IActionResult Index()
        {
            List<ApplicationRoleDTO> lstApplicationRoleDTO = new List<ApplicationRoleDTO>();

            IEnumerable<ApplicationRole> lstApplicationRoles  = unitOfWork.rolesRepository.GetAll();
            foreach (var item in lstApplicationRoles)
            {
                lstApplicationRoleDTO.Add(mapper.Map<ApplicationRoleDTO>(item));
            }
            return View(lstApplicationRoleDTO);
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            ApplicationRoleDTO roleDTO = new ApplicationRoleDTO();
            if (id == null)
            {
                //for create
                return View(roleDTO);
            }
            //for edit
            ApplicationRole objrole = unitOfWork.rolesRepository.Get(id.GetValueOrDefault());
            if (objrole == null)
            {
                return NotFound();
            }
            roleDTO = mapper.Map<ApplicationRoleDTO>(objrole);
            return View(roleDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ApplicationRoleDTO model)
        {
            if (ModelState.IsValid)
            {
                ApplicationRole objRole = mapper.Map<ApplicationRole>(model);
                
                if (model.Id == 0)
                {
                    unitOfWork.rolesRepository.Add(objRole);
                }
                else
                {
                    unitOfWork.rolesRepository.Update(objRole);
                }
                unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        #endregion
    }
}
