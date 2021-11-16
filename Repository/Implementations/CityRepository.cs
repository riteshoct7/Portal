using Entities.Models;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public  class CityRepository :Repository<City>,ICityRepository
    {
        #region Fields
        private readonly ApplicationDbContext db;
        #endregion

        #region Constructors
        public CityRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
        #endregion

        #region Methods

        #endregion
    }
}
