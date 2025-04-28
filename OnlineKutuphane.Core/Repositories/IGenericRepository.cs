using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineKutuphane.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        //Yeni bir nesneyi veritabanına ekler.
        void Add(T entity);

        //Belirtilen ID'ye sahip kaydı getirir
        T? GetById(int id);

        //İlişkili verilerle birlikte kaydı getirir
        T? GetByIdWithInclude(int id, params Expression<Func<T, object>>[] includes);

        //Belirli bir ID'ye sahip kaydı günceller
        bool Update(int id, T updated);

        //Belirli bir ID'ye sahip Kaydı siler
        bool Delete(int id);

        //Tüm kayıtları ilişkili verilerle (navigation properties) birlikte getirir.
        IEnumerable<T> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties);

        //"Veritabanındaki tüm kayıtları listeler
        List<T> GetAll();
    }
}
