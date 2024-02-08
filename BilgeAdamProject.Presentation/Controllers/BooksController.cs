using BilgeAdamProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdamProject.Presentation.Controllers;

[Route("api/books")]
[ApiController]
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
}

