using Microsoft.EntityFrameworkCore;
using OnlineKutuphane.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineKutuphane.Data.Repositories
{
    //Tüm entity'ler için tekrar kullanılabilir genel veri işlemlerini sağlar
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        // DbContext dependency injection ile alınır
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        // Yenİ veri ekler
        public void Add(T entity) => _context.Set<T>().Add(entity);

        //ID ile veri getirir
        public T? GetById(int id) => _context.Set<T>().Find(id);

        //İlişkili verilerle birlikte veri getirir 
        public T? GetByIdWithInclude(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            //Include ile ilişkili tablolar dahil edilir
            foreach (var include in includes)
                query = query.Include(include);

            //Id property'si üzerinden filtreleme yapılır
            return query.FirstOrDefault(e => EF.Property<int>(e, "Id") == id);
        }

        //Güncelleme işlemi yapar
        public bool Update(int id, T updated)
        {
            var existing = _context.Set<T>().Find(id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(updated);
            return true;
        }

        //Silme işlemi yapar
        public bool Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null) return false;

            _context.Set<T>().Remove(entity);
            return true;
        }

        //Veritabanından veri çekerken ilişkili tabloları (navigation property) da dahil eder.
        public IEnumerable<T> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>(); //Tüm entity’leri al

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty); //İlgili özelliği ekle (örnek: Category)
            }

            return query;
        }

        //Tüm verileri getirir
        public List<T> GetAll() => _context.Set<T>().ToList();
    }
}
