using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Web.Areas.Admin.Models.Dtos;

namespace Web.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        #region Fields

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        #endregion

        #region Constructors
        public CategoryController(IUnitOfWork unitOfWork ,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            IEnumerable<Category> lstcatgeory = unitOfWork.categoryRepository.GetAll();
         
            List<CategoryListingDTO> lst = new List<CategoryListingDTO>();
            foreach (var item in lstcatgeory)
            {                
                lst.Add(mapper.Map<CategoryListingDTO>(item));
            }
            return View(lst);
        } 
        #endregion
    }
}
