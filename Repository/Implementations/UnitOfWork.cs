using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public  class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly ApplicationDbContext db;
        
        #endregion

        #region Constructors
        public UnitOfWork(ApplicationDbContext db)
        {
            this.db = db;
            categoryRepository = new CategoryRepository(db);    
            countryRepository  = new CountryRepository(db);
            storedProcedureRepository = new StoredProcedureRepository(db);
        }
        #endregion

        #region Methods
        public ICategoryRepository categoryRepository { get; private set; }

        public ICountryRepository countryRepository { get; private set; }

        public IStoredProcedureRepository storedProcedureRepository { get; private set; }

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
