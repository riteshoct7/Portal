using Entities.Models;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public  class StateRepository : Repository<State>, IStateRepository
    {
        #region Fields
        private readonly ApplicationDbContext db;
        #endregion

        #region Constructors
        public StateRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
        #endregion

        #region Methods

        #endregion
    }
}
