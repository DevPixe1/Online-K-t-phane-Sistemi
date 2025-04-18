﻿using Microsoft.AspNetCore.Mvc;
using OnlineKutuphane.Core;
using OnlineKutuphane.Core.Dtos;

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
            try
            {
                if (dto == null || string.IsNullOrEmpty(dto.Title))
                    return BadRequest("Kitap bilgileri eksik!");

                var book = new Book
                {
                    Title = dto.Title,
                    Author = dto.Author,
                    PublishedYear = dto.Year
                };

                _bookService.Add(book);

                return Ok("Kitap başarıyla eklendi.");
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
                var book = _bookService.GetById(id);
                if (book == null) return NotFound();

                var dto = new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Year = book.PublishedYear
                };

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
            try
            {
                var updated = new Book
                {
                    Title = dto.Title,
                    Author = dto.Author,
                    PublishedYear = dto.Year
                };

                var result = _bookService.Update(id, updated);
                if (!result) return NotFound();

                return Ok("Güncellendi.");
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
                if (!result) return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
    }
}
