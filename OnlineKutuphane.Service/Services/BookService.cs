using AutoMapper;
using OnlineKutuphane.Core;
using OnlineKutuphane.Core.Dtos;
using OnlineKutuphane.Core.Repositories;
using OnlineKutuphane.Core.Services;

namespace OnlineKutuphane.Service
{
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
            var existingBook = _unitOfWork.Books.GetById(id);
            if (existingBook == null) return false;

            _mapper.Map(dto, existingBook); // Güncellemeyi dto ile yap
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var result = _unitOfWork.Books.Delete(id);
            if (result)
                _unitOfWork.SaveChanges();
            return result;
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
            var books = _unitOfWork.Books.GetAll();
            return books.Select(b => _mapper.Map<BookDto>(b)).ToList();
        }
    }
}
