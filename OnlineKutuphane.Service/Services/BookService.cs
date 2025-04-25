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
        
        //Kitabı ekler
        public void Add(CreateBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            _unitOfWork.Books.Add(book);
            _unitOfWork.SaveChanges();
        }

        //Kitabı günceller
        public bool Update(int id, UpdateBookDto dto)
        {
            var existing = _unitOfWork.Books.GetById(id);
            if (existing == null) return false;

            _mapper.Map(dto, existing); // DTO'yu mevcut entitiy'e uygula
            _unitOfWork.SaveChanges();
            return true;
        }

        //Kitap siler
        public bool Delete(int id)
        {
            var success = _unitOfWork.Books.Delete(id);
            if (!success) return false;

            _unitOfWork.SaveChanges();
            return true;
        }

        //Kitabı ID ile getirir.
        public BookDto? GetById(int id)
        {
            var book = _unitOfWork.Books.GetById(id);
            return book == null ? null : _mapper.Map<BookDto>(book);
        }

        //Kitabı kategori bilgisiyle birlikte getirir
        public BookDto? GetByIdWithCategory(int id)
        {
            var book = _unitOfWork.Books.GetByIdWithInclude(id, b => b.Category);
            return book == null ? null : _mapper.Map<BookDto>(book);
        }

        //Tüm kitapları listeler
        public List<BookDto> GetAll()
        {
            var books = _unitOfWork.Books.GetAll();
            return _mapper.Map<List<BookDto>>(books);
        }
    }
}
