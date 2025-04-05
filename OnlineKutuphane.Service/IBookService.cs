using OnlineKutuphane.Core.DTOs;

namespace OnlineKutuphane.Service
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBooksAsync();
        Task<BookDto> GetBookByIdAsync(int id);
        Task<int> AddBookAsync(BookCreateDto bookDto);
        Task<bool> UpdateBookAsync(int id, BookUpdateDto bookDto);
        Task<bool> DeleteBookAsync(int id);
    }
}
