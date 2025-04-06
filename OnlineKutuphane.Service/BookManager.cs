using OnlineKutuphane.Core;

namespace OnlineKutuphane.Service
{
    // Service sınıfı: iş mantığını içerir, repository'e bağımlıdır
    public class BookManager : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Add(Book book)
        {
            // Burada iş mantığı uygulanabilir, örn: loglama, validasyon vs.
            _bookRepository.Add(book);
        }

        public Book? GetById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public bool Update(int id, Book updatedBook)
        {
            return _bookRepository.Update(id, updatedBook);
        }

        public bool Delete(int id)
        {
            return _bookRepository.Delete(id);
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }
    }
}
