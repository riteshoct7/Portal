using Entities.Models;

namespace Repository.Interfaces
{
    public  interface ICountryRepository : IRepository<Country>
    {
        #region Methods
        Country GetCountryByName(string countryName);   
        #endregion
    }
}
