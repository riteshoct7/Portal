using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Web.Areas.Admin.Models.Dtos;

namespace Web.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        #region Fields

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper; 

        #endregion

        #region Constructors
        public ProductController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            IEnumerable<Product> lstProduct = unitOfWork.productRepository.GetAll();
            List<ProductListingDTO> lst = new List<ProductListingDTO>();
            foreach (var item in lstProduct)
            {
                lst.Add(mapper.Map<ProductListingDTO>(item));
            }
            return View(lst);
        } 
        #endregion

    }
}
