using AutoMapper;
using OnlineKutuphane.Core;
using OnlineKutuphane.Core.DTOs;
using OnlineKutuphane.Data.Repositories;

namespace OnlineKutuphane.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return _mapper.Map<List<BookDto>>(books);
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<BookDto>(book);
        }

        public async Task<int> AddBookAsync(BookCreateDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepository.AddAsync(book);
            return book.Id;
        }

        public async Task<bool> UpdateBookAsync(int id, BookUpdateDto bookDto)
        {
            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook == null) return false;

            _mapper.Map(bookDto, existingBook);
            await _bookRepository.UpdateAsync(existingBook);
            return true;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook == null) return false;

            await _bookRepository.DeleteAsync(existingBook);
            return true;
        }
    }
}
