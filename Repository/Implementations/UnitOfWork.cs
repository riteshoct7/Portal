using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public  class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        #endregion

        #region Constructors
        public UnitOfWork(ApplicationDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            categoryRepository = new CategoryRepository(db);    
            countryRepository  = new CountryRepository(db);
            authenticationRepository = new AuthenticationRepository(userManager,signInManager);
            authorizationRepository = new AuthorizationRepository(roleManager);
            storedProcedureRepository = new StoredProcedureRepository(db);
            rolesRepository = new RolesRepository(db);
            stateRepository = new StateRepository(db);
            cityRepository = new CityRepository(db);
            productRepository = new ProductRepository(db);
        }
        #endregion

        #region Methods
        public ICategoryRepository categoryRepository { get; private set; }

        public ICountryRepository countryRepository { get; private set; }

        public IStoredProcedureRepository storedProcedureRepository { get; private set; }

        public IAuthenticationRepository authenticationRepository { get; private set; }
        public IAuthorizationRepository authorizationRepository { get; private set; }

        public IRolesRepository rolesRepository { get; private set; }

        public IStateRepository stateRepository { get; private set; }

        public ICityRepository cityRepository { get; private set; }

        public IProductRepository productRepository { get; private set; }

        public void Dispose()
        {
            db.Dispose();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        } 
        #endregion
    }
}
