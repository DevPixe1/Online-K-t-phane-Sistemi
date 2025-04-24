using Microsoft.AspNetCore.Mvc;
using OnlineKutuphane.Core.Dtos;
using OnlineKutuphane.Core.Services;

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
        public IActionResult AddBook([FromBody] CreateBookDto dto)
        {
            if (dto == null)
                return BadRequest("Veri eksik.");

            try
            {
                _bookService.Add(dto);
                return Ok("Kitap eklendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            try
            {
                var dto = _bookService.GetByIdWithCategory(id);
                if (dto == null)
                    return NotFound("Kitap bulunamadı.");

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookDto dto)
        {
            if (dto == null)
                return BadRequest("Güncelleme verisi eksik.");

            try
            {
                var result = _bookService.Update(id, dto);
                return result ? Ok("Güncellendi.") : NotFound("Kitap bulunamadı.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                var result = _bookService.Delete(id);
                return result ? NoContent() : NotFound("Kitap bulunamadı.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
    }
}
