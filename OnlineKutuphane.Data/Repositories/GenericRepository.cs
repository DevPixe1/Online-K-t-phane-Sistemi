using Microsoft.EntityFrameworkCore;
using OnlineKutuphane.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineKutuphane.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T entity) => _context.Set<T>().Add(entity);

        public T? GetById(int id) => _context.Set<T>().Find(id);

        public T? GetByIdWithInclude(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var include in includes)
                query = query.Include(include);

            return query.FirstOrDefault(e => EF.Property<int>(e, "Id") == id);
        }

        public bool Update(int id, T updated)
        {
            var existing = _context.Set<T>().Find(id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(updated);
            return true;
        }

        public bool Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null) return false;

            _context.Set<T>().Remove(entity);
            return true;
        }

        public List<T> GetAll() => _context.Set<T>().ToList();
    }
}
