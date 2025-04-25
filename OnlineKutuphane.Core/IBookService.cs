using OnlineKutuphane.Core.Dtos;

namespace OnlineKutuphane.Core.Services
{
    // Amaç: Kitaplara dair işlemleri (ekleme, güncelleme, silme, listeleme) servis katmanında tanımlamak için kullanılır.
    // Controller katmanı bu arayüzü kullanarak iş mantığına erişir.
    public interface IBookService
    {
        void Add(CreateBookDto dto);
        bool Update(int id, UpdateBookDto dto);
        bool Delete(int id);
        BookDto? GetById(int id);
        BookDto? GetByIdWithCategory(int id);
        IEnumerable<BookDto> GetBooksByCategory(int categoryId);
        List<BookDto> GetAll();
    }
}
