using Entities.Models;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public  class RolesRepository :Repository<ApplicationRole>,IRolesRepository
    {
        #region Fields
        private readonly ApplicationDbContext db;
        #endregion

        #region Constructors

        public RolesRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        } 

        #endregion

    }
}
