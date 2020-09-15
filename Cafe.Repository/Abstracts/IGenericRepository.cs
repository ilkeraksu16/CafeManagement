using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repository.Abstracts
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        #region Insert
        bool Insert(T entity);

        int InsertTakeId(T entity);

        #endregion

        #region Update
        bool Update(T entity);
        #endregion

        #region Delete
        bool Delete(int id);
        #endregion

        #region Get
        List<T> GetAll();
        T GetById(int id);
        #endregion



    }
}
