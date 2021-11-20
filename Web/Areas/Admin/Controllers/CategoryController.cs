using AspNetCoreHero.ToastNotification.Abstractions;
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
        private readonly INotyfService notyf;

        #endregion

        #region Constructors
        public CategoryController(IUnitOfWork unitOfWork ,IMapper mapper, INotyfService notyf)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.notyf = notyf;
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

        
        public IActionResult Delete(int id)
        {
            Category objCategory = unitOfWork.categoryRepository.Get(id);            
            if (objCategory == null)
            {
                notyf.Error("Category Not Found,Error while deleting", 10);
                return Json(new { success = false, message = "Error while deleting" });
            }            
            unitOfWork.categoryRepository.Remove(mapper.Map<Category>(objCategory));
            unitOfWork.SaveChanges();            
            notyf.Information("Category Deleted Successfully", 10);
            //return RedirectToAction(nameof(Index));
            return Json(new { success = true, message = "Delete Successful" });



        }

        #endregion
    }
}
