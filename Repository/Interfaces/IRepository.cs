namespace Repository.Interfaces
{
    public  interface IRepository<T> where T : class
    {
        #region MyRegion

        T Get(int id);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Update(T entity);

        T Find(T entity);

        void Remove(int id);

        void Remove(T entity); 
        #endregion
    }
}
