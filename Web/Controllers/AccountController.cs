using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Web.Models;

namespace Web.Controllers
{
    public class AccountController : Controller
    {

        #region Fields

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        #endregion

        #region Constructors
        public AccountController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #endregion

        #region Methods
        
        [HttpGet]
        public IActionResult Register()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {            

            if(ModelState.IsValid)
            {
                ApplicationUser objUser = mapper.Map<ApplicationUser>(registerViewModel);
                var user = new ApplicationUser()
                {
                    UserName = registerViewModel.Email,
                    Email = registerViewModel.Email,
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName
                };
                objUser.UserName = registerViewModel.Email;
                //var result = await userManager.CreateAsync(user, registerViewModel.Password);
                var result = await userManager.CreateAsync(objUser, registerViewModel.Password);
                if (result.Succeeded)
                {
                    //await signInManager.SignInAsync(user, isPersistent: false);
                    await signInManager.SignInAsync(objUser, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);

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
        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {            
            return View();
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
