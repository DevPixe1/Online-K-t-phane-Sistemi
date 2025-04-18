using OnlineKutuphane.Core;
using OnlineKutuphane.Core.Repositories;

namespace OnlineKutuphane.Core
{
    public interface IUnitOfWork
    {
        IGenericRepository<Book> Books { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
