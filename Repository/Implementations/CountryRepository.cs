using Entities.Models;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        #region Fields
        private readonly ApplicationDbContext db; 
        #endregion

        #region Constructors
        public CountryRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        } 
        #endregion

        #region Methods
        public Country GetCountryByName(string countryName)
        {
            return db.Countries.Where(x => x.CountryName == countryName).FirstOrDefault();
        } 
        #endregion
    }
}
