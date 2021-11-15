namespace Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable  
    {

        #region Properties
        ICategoryRepository categoryRepository { get; }
        ICountryRepository countryRepository { get; }
        IStoredProcedureRepository storedProcedureRepository { get; }

        IAuthenticationRepository authenticationRepository { get; }
        IAuthorizationRepository authorizationRepository { get; }
        void SaveChanges();

        #endregion
    }
}
