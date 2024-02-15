using BilgeAdamProject.Entities.DataTransferObjects;
using BilgeAdamProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdamProject.Presentation.Controllers;

[Route("api/books")]
[ApiController]
//cach'leme kar etmiyor.
//[ResponseCache(VaryByHeader = "User-Agent", Duration = 120)]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllBooksAsync()
    {
        var books = await _bookService.GetAllBooksAsync();
        Response.Headers.Add("DataLength", books.Count.ToString());
        return Ok(books);
    }
    [HttpPost]
    public async Task<IActionResult> CreateOneBook([FromBody] BookDtoForInsertion bookDto)
    {
        var id = await _bookService.AddOneBookAsync(bookDto);
        return NoContent(); //Ok(JsonSerializer.Serialize(id));
    }
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetOneBookByIdAsync([FromRoute(Name = "id")] Guid id)
    {
        var book = await _bookService.GetOneBookByIdAsync(id);
        return Ok(book);
    }
}
