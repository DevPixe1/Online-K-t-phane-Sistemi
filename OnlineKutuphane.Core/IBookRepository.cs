using OnlineKutuphane.Core;
using System.Collections.Generic;

namespace OnlineKutuphane.Core
{
    // Repository arayüzü, veri erişim işlemlerini tanımlar (abstract)
    public interface IBookRepository
    {
        void Add(Book book);
        Book? GetById(int id);
        bool Update(int id, Book updatedBook);
        bool Delete(int id);
        List<Book> GetAll(); // İsteğe bağlı listeleme
    }
}
