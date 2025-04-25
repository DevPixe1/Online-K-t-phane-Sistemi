using OnlineKutuphane.Core;
using OnlineKutuphane.Core.Repositories;

namespace OnlineKutuphane.Core
{
    // Amaç: Repository'leri bir arada tutmak ve işlemleri tek noktadan yönetmek. 
    // Veritabanı işlemlerini bütünlük içinde yapmayı sağlar (örneğin SaveChanges ile).
    public interface IUnitOfWork
    {
        IGenericRepository<Book> Books { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
