using Cafe.Repository.Abstracts;
using Cafe.Repository.Connection;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repository.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        readonly IDbConnection _dbConnection;
        readonly string _tableName;
        public GenericRepository()
        {
            _dbConnection = ConnectionFactory.CreateDbConnection("dsf");
            _tableName = typeof(T).Name;
        }
        #region Delete
        public bool Delete(int id)
        {
            var sql = $"DELETE FROM {_tableName} WHERE Id={id}";
            return _dbConnection.Execute(sql)>0;
        } 
        #endregion

        #region Get
        public List<T> GetAll()
        {
            var sql = $"SELECT * FROM {_tableName}";
            return _dbConnection.Query<T>(sql).ToList();
        }

        public T GetById(int id)
        {
            var sql = $"SELECT * FROM {_tableName} WHERE Id=@id";
            var parametre = new DynamicParameters();
            parametre.Add("@id", id);
            return _dbConnection.QueryFirstOrDefault<T>(sql, parametre);
        } 
        #endregion

        #region Insert
        public bool Insert(T entity)
        {
            var sql = GenerateQuery<T>.GenerateInsertQuery(false);
            return _dbConnection.Execute(sql,entity)>0;
        }

        public int InsertTakeId(T entity)
        {
            var sql = GenerateQuery<T>.GenerateInsertQuery(true);
            return _dbConnection.Execute(sql, entity);
        }
        #endregion

        #region Update
        public bool Update(T entity)
        {
            var sql = GenerateQuery<T>.GenerateUpdateQuery();
            return _dbConnection.Execute(sql, entity) > 0;
        } 
        #endregion
        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbConnection.Dispose();
            }
                
        }
        #endregion
    }
}
