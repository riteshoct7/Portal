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

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> lstcatgeory = unitOfWork.categoryRepository.GetAll().Where(x=>x.Enabled == true);
         
            List<CategoryListingDTO> lst = new List<CategoryListingDTO>();
            foreach (var item in lstcatgeory)
            {                
                lst.Add(mapper.Map<CategoryListingDTO>(item));
            }
            return View(lst);
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            CategoryListingDTO catgeory = new CategoryListingDTO();
            if (id == null) 
            {
                //for create
                return View(catgeory);
            }
            //for edit
            Category objCategory =  unitOfWork.categoryRepository.Get(id.GetValueOrDefault());
            if (objCategory == null)
            {
                return NotFound();
            }
            catgeory = mapper.Map<CategoryListingDTO>(objCategory);
            return View(catgeory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CategoryListingDTO model)
        {
            if (ModelState.IsValid)
            {
                Category objCategory = mapper.Map<Category>(model);
                objCategory.Enabled = true;
                if (model.CategoryId ==0)
                {                    
                    unitOfWork.categoryRepository.Add(objCategory);
                }
                else
                {
                    unitOfWork.categoryRepository.Update(objCategory);
                }
                unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index)); 
            }
            return View(model);
        }

        #endregion
    }
}
