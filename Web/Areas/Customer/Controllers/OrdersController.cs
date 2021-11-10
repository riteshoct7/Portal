using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace Web.Areas.Customer.Controllers
{
    public class OrdersController : BaseController
    {
        #region Fields
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        #endregion

        #region Constructors
        public OrdersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            return View();
        } 
        #endregion
    }
}
