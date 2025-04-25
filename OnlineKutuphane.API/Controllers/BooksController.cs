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

        //Yeni  kitap ekler
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookDto dto)
        {
            //Gönderilen veri boşsa uyarı döner
            if (dto == null)
                return BadRequest("Veri eksik. Lütfen geçerli kitap bilgileri gönderin.");

            try
            {
                _bookService.Add(dto); // Servis aracılığıyla ekleme işlemi yapılır
                return Ok("Kitap başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                //Beklenmeyen bir hata oluşursa 500 döner
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        //Belirli bir kitabı ID ile getirir
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            try
            {
                var dto = _bookService.GetByIdWithCategory(id);

                if (dto == null)
                    return NotFound("Belirtilen ID'ye sahip kitap bulunamadı.");

                return Ok(dto); //Kitap bilgisi BookDto olarak döner
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        //Var olan bir kitabı günceller
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookDto dto)
        {
            if (dto == null)
                return BadRequest("Güncelleme verisi eksik. Lütfen geçerli bilgiler sağlayın.");

            try
            {
                var result = _bookService.Update(id, dto);

                if (!result)
                    return NotFound("Güncellenecek kitap bulunamadı.");

                return Ok("Kitap başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        //Bir kitabı silmer
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                var result = _bookService.Delete(id);

                if (!result)
                    return NotFound("Silinecek kitap bulunamadı.");

                return NoContent(); //Başarıyla silinmişse 204 döner
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
    }
}
