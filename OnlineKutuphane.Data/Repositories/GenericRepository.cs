using Microsoft.EntityFrameworkCore;
using OnlineKutuphane.Core.Repositories;

namespace OnlineKutuphane.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity) => _dbSet.Add(entity);
        public T? GetById(int id) => _dbSet.Find(id);
        public List<T> GetAll() => _dbSet.ToList();

        public bool Update(int id, T updated)
        {
            var existing = _dbSet.Find(id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(updated);
            return true;
        }

        public bool Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            return true;
        }
    }
}
