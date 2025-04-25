using OnlineKutuphane.Core;
using OnlineKutuphane.Core.Repositories;
using OnlineKutuphane.Data.Repositories;

namespace OnlineKutuphane.Data
{
    //Birden fazla repository ile çalışırken işlemleri tek noktadan yönetmek için kullanılır
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;


        //Book repository'e erişimi sağlar (IGenericRepository üzerinden)
        public IGenericRepository<Book> Books { get; }

        public UnitOfWork(AppDbContext context, IGenericRepository<Book> bookRepository)
        {
            _context = context;
            Books = bookRepository;
        }

        //Yapılan değişiklikleri veritabanına kaydeder (senkron)
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        //Yapılan değişiklikleri veritabanına kaydeder (asenkron)
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
