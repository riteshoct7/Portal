using Dapper;
using Microsoft.Data.SqlClient;
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

        public T Single<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                return (T)Convert.ChangeType(con.ExecuteScalar<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure),typeof(T));                
            }
        }

        public void Execute(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                con.Execute(procedureName,param,commandType:System.Data.CommandType.StoredProcedure);
            }
        }

        public T OneRecord<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                var value = con.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
                return (T)Convert.ChangeType(value.FirstOrDefault(), typeof(T)); 
            }            
        }

        public IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                return con.Query<T>( procedureName,param, commandType: System.Data.CommandType.StoredProcedure);                
            }            
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                var result = SqlMapper.QueryMultiple(con, procedureName,param, commandType: System.Data.CommandType.StoredProcedure);
                var item1 = result.Read<T1>().ToList();
                var item2 = result.Read<T2>().ToList();

                if (item1 != null && item2 != null)
                {
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                }
            }
            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());
        }

        public void Dispose()
        {
            db.Dispose();
        }

        #endregion
    }
}
