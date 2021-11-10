using Entities.Models;

namespace Repository.Interfaces
{
    public interface ICategoryRepository :IRepository<Category>
    {
        #region Methods
        Category GetCategoryByName (string categoryame); 
        #endregion
    }
}
