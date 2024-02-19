using BilgeAdamProject.Entities.DataTransferObjects;
using BilgeAdamProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdamProject.Presentation.Controllers;

[Route("api/authors")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }
    [HttpPost]
    public async Task<IActionResult> AddOneAuthor([FromBody] AuthorDtoForInsertion authorDto)
    {
        await _authorService.AddOneAuthorAsync(authorDto);
        return StatusCode(201, authorDto);
    }

}

