using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    [HttpGet]
    public IActionResult GetBooks()
    {
        return Ok(new List<string> { "Kitap 1", "Kitap 2" });
    }
}
