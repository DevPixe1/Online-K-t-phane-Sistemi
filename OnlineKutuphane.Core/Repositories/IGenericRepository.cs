using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineKutuphane.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        //Yeni kitabı veritabanına ekler.
        void Add(T entity);

        //Belirli bir ID'ye sahip kitabı getirir.
        T? GetById(int id);

        //Kitabı belirli ilişkili (include edilen) nesnelerle birlikte getirir
        T? GetByIdWithInclude(int id, params Expression<Func<T, object>>[] includes);

        //Verilen ID'ye sahip entity'yi günceller
        bool Update(int id, T updated);

        //Verilen ID'ye sahip entity'yi siler
        bool Delete(int id);

        //Veritabanındaki tüm entity'leri listeler
        List<T> GetAll();
    }
}