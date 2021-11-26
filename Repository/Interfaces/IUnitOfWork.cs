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

        IRolesRepository rolesRepository { get; }

        IStateRepository stateRepository { get; }

        ICityRepository cityRepository { get; }

        IProductRepository productRepository { get; }   

        bool SaveChanges();

        #endregion
    }
}
