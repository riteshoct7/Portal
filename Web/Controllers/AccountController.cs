using AutoMapper;
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

        #endregion

        #region Constructors
        public AccountController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
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
        public IActionResult Register(RegisterViewModel registerViewModel)
        {            
            return View();
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

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }


        #endregion
    }
}
