using AutoMapper;
using OnlineKutuphane.Core;
using OnlineKutuphane.Core.Dtos;
using OnlineKutuphane.Core.Repositories;
using OnlineKutuphane.Core.Services;

namespace OnlineKutuphane.Service
{
    //Kitap işlemlerini yönetir
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(CreateBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            _unitOfWork.Books.Add(book);
            _unitOfWork.SaveChanges();
        }

        public bool Update(int id, UpdateBookDto dto)
        {
            var existing = _unitOfWork.Books.GetById(id);
            if (existing == null) return false;

            _mapper.Map(dto, existing);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var success = _unitOfWork.Books.Delete(id);
            if (!success) return false;

            _unitOfWork.SaveChanges();
            return true;
        }

        public BookDto? GetById(int id)
        {
            var book = _unitOfWork.Books.GetById(id);
            return book == null ? null : _mapper.Map<BookDto>(book);
        }

        public BookDto? GetByIdWithCategory(int id)
        {
            var book = _unitOfWork.Books.GetByIdWithInclude(id, b => b.Category);
            return book == null ? null : _mapper.Map<BookDto>(book);
        }

        public List<BookDto> GetAll()
        {
            // Kategori dahil olarak kitapları getir
            var books = _unitOfWork.Books.GetAllWithInclude(b => b.Category).ToList();
            return _mapper.Map<List<BookDto>>(books);
        }

        public IEnumerable<BookDto> GetBooksByCategory(int categoryId)
        {
            // Sadece ilgili kategoriye ait kitapları getirirken, Category bilgisini de dahil et
            var books = _unitOfWork.Books
                .GetAllWithInclude(b => b.Category)
                .Where(b => b.CategoryId == categoryId)
                .ToList();

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }
    }
}
