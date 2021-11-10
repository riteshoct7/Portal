using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Fields

        private readonly ApplicationDbContext db;
        internal DbSet<T> dbSet;

        #endregion

        #region Constructors
        public Repository(ApplicationDbContext db)
        {
            this.db = db;
            dbSet = db.Set<T>();    
        } 
        #endregion

        #region Methods
        public void Add(T entity)
        {
            db.Add(entity);
        }

        public T Find(T entity)
        {
            return dbSet.Find(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(int id)
        {
            db.Remove(id);
        }

        public void Remove(T entity)
        {
            db.Remove(entity);        
        }

        public void Update(T entity)
        {
            db.Update(entity);
        } 

        #endregion
    }
}
