using Microsoft.AspNetCore.Mvc;
using OnlineKutuphane.Core;

namespace OnlineKutuphane.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _bookService.Add(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var result = _bookService.Update(id, updatedBook);
            if (!result)
                return NotFound();

            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var result = _bookService.Delete(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
