using Entities.Models;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public  class ProductRepository : Repository<Product>, IProductRepository
    
    {
        #region Fields
        private readonly ApplicationDbContext db; 
        #endregion

        #region Constructors
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
        #endregion

        #region Methods

        #endregion
    }
}
