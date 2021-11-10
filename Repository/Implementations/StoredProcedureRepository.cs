using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class StoredProcedureRepository : IStoredProcedureRepository
    {
        #region Fields

        private readonly ApplicationDbContext db;
        private static string ConnectionString = "";

        #endregion

        #region Constructors
        public StoredProcedureRepository(ApplicationDbContext db)
        {
            this.db = db;
            ConnectionString = db.Database.GetDbConnection().ConnectionString;
        }
        #endregion

        #region Methods

        #endregion
    }
}
