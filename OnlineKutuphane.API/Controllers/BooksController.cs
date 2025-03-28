using Microsoft.AspNetCore.Mvc;
using OnlineKutuphane.Core;
using OnlineKutuphane.Data;

namespace OnlineKutuphane.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (book == null || string.IsNullOrEmpty(book.Title))
            {
                return BadRequest("Kitap bilgileri eksik!");
            }

            _context.Books.Add(book);
            _context.SaveChanges();  // Veritabanına kaydet

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}
