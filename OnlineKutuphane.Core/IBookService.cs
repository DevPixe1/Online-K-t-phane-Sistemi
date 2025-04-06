using OnlineKutuphane.Core;
using System.Collections.Generic;

namespace OnlineKutuphane.Core
{
    // Servis arayüzü: iş mantığı seviyesinde yapılacak işlemleri tanımlar
    public interface IBookService
    {
        void Add(Book book);
        Book? GetById(int id);
        bool Update(int id, Book updatedBook);
        bool Delete(int id);
        List<Book> GetAll(); // Listeleme opsiyonel ama faydalı
    }
}
