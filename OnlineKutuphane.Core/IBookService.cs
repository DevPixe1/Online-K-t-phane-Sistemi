using OnlineKutuphane.Core.Dtos;

namespace OnlineKutuphane.Core.Services
{
    public interface IBookService
    {
        void Add(CreateBookDto dto);
        bool Update(int id, UpdateBookDto dto);
        bool Delete(int id);
        BookDto? GetById(int id);
        BookDto? GetByIdWithCategory(int id);
        List<BookDto> GetAll();
    }
}
