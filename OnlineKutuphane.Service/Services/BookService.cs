using OnlineKutuphane.Core;
using OnlineKutuphane.Core.Repositories;

namespace OnlineKutuphane.Service
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _repository;

        public BookService(IGenericRepository<Book> repository)
        {
            _repository = repository;
        }

        public void Add(Book book)
        {
            _repository.Add(book);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<Book> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public Book? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Update(int id, Book updatedBook)
        {
            return _repository.Update(id, updatedBook);
        }
    }
}
