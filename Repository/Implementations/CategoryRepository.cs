using Entities.Models;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        #region Fields
        private readonly ApplicationDbContext db;
        #endregion

        #region Constructors
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
        #endregion

        #region Methods
        public Category GetCategoryByName(string categoryame)
        {
            return db.Categories.Where(x => x.CategoryName == categoryame).FirstOrDefault();
        } 
        #endregion

    }
            
}
