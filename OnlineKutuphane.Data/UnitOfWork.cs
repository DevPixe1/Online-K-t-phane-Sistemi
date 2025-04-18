using OnlineKutuphane.Core;
using OnlineKutuphane.Core.Repositories;
using OnlineKutuphane.Data.Repositories;

namespace OnlineKutuphane.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGenericRepository<Book> Books { get; }

        public UnitOfWork(AppDbContext context, IGenericRepository<Book> bookRepository)
        {
            _context = context;
            Books = bookRepository;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
