using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Common;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        #region Fields

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly INotyfService notyf;

        #endregion

        #region Constructors
        public AccountController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager, INotyfService notyf)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager; 
            this.signInManager = signInManager;
            this.notyf = notyf;
        }

        #endregion

        #region Methods
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string? returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;

            if(!unitOfWork.authorizationRepository.CheckRoleExist(Constants.CustomerRoleTitle))
            {
                ApplicationRole obj = new ApplicationRole() { Name = Constants.CustomerRoleTitle, Description = Constants.CustomerRoleTitle };
                bool result = unitOfWork.authorizationRepository.AddRole(obj).Result;                
                if(result)
                {
                    notyf.Success("Customer Role Created", 10);
                }
            }
            else
            {
                notyf.Information("Customer Role Already Created", 10);
            }

            if (!unitOfWork.authorizationRepository.CheckRoleExist(Constants.AdminRoleTitle))
            {
                ApplicationRole obj = new ApplicationRole() { Name = Constants.AdminRoleTitle, Description = Constants.AdminRoleTitle };
                bool result = unitOfWork.authorizationRepository.AddRole(obj).Result;
                if (result)
                {
                    notyf.Success("Admin Role Created", 10);
                }
            }
            else
            {
                notyf.Information("Admin Role Already Created", 10);
            }


            RegisterViewModel registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult Register(RegisterViewModel registerViewModel , string? returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                ApplicationUser objUser = mapper.Map<ApplicationUser>(registerViewModel);
                objUser.UserName = registerViewModel.Email;
                var result = unitOfWork.authenticationRepository.Register(objUser, registerViewModel.Password);
                if (result)
                {
                    notyf.Success("Registered Successfully");
                    return LocalRedirect(returnurl);
                }
                else
                {
                    notyf.Error("Registration Failed Please Try Again");
                }
            }   
            return View(registerViewModel);
        }
        private void AddErrors (IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(String.Empty, error.Description);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;                        
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel loginViewModel, string? returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                bool isLockedOut;
                var result = unitOfWork.authenticationRepository.SignIn(loginViewModel.Email, loginViewModel.Password, out  isLockedOut);
                if (result != null)
                {               
                    return LocalRedirect(returnurl);
                    //return RedirectToAction("Index", "Home");
                    //if (result.Roles.Contains("Admin"))
                    //{
                    //    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    //}
                }
                else
                {
                    if (isLockedOut)
                    {
                        notyf.Information("Your Account has been locked out please try after some time", 10);                        
                    }
                    else
                    {
                        notyf.Warning("Invalid Login Attempt", 10);
                    }
                    return View(loginViewModel);
                }                                
            }
            return View(loginViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {

            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index),"Home");
        }
        
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }


        #endregion
    }
}
