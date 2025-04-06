using OnlineKutuphane.Core;
using Microsoft.EntityFrameworkCore;

namespace OnlineKutuphane.Data
{
    // Repository implementasyonu, veritabanı işlemlerini gerçekleştirir
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public Book? GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public bool Update(int id, Book updatedBook)
        {
            var book = _context.Books.Find(id);
            if (book == null) return false;

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.PublishedYear = updatedBook.PublishedYear;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            _context.SaveChanges();
            return true;
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }
    }
}
