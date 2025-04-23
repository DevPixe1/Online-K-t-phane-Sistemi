using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineKutuphane.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        T? GetById(int id);
        T? GetByIdWithInclude(int id, params Expression<Func<T, object>>[] includes);
        bool Update(int id, T updated);
        bool Delete(int id);
        List<T> GetAll();
    }
}