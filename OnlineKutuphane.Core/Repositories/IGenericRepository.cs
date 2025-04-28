using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineKutuphane.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        //Yeni bir entity'yi veritabanına ekler.
        void Add(T entity);

        //Belirli bir ID'ye sahip entity'yi getirir.
        T? GetById(int id);

        //Entity'yi belirtilen ilişkili (include edilen) nesnelerle birlikte getirir.
        T? GetByIdWithInclude(int id, params Expression<Func<T, object>>[] includes);

        //Belirli bir ID'ye sahip entity'yi günceller.
        bool Update(int id, T updated);

        //Belirli bir ID'ye sahip entity'yi siler.
        bool Delete(int id);

        //Tüm entity'leri ilişkili verilerle (navigation properties) birlikte getirir.
        IEnumerable<T> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties);

        //Veritabanındaki tüm entity'leri listeler.
        List<T> GetAll();
    }
}
