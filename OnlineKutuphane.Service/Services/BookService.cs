using OnlineKutuphane.Core;
using OnlineKutuphane.Core.Repositories;

namespace OnlineKutuphane.Service
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Book book)
        {
            _unitOfWork.Books.Add(book);
            _unitOfWork.SaveChanges();
        }

        public Book? GetById(int id)
        {
            return _unitOfWork.Books.GetById(id);
        }

        public bool Update(int id, Book updatedBook)
        {
            var result = _unitOfWork.Books.Update(id, updatedBook);
            if (result)
                _unitOfWork.SaveChanges();
            return result;
        }

        public bool Delete(int id)
        {
            var result = _unitOfWork.Books.Delete(id);
            if (result)
                _unitOfWork.SaveChanges();
            return result;
        }

        public List<Book> GetAll()
        {
            return _unitOfWork.Books.GetAll();
        }
    }
}
