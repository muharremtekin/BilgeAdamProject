using AutoMapper;
using BilgeAdamProject.Entities.DataTransferObjects;
using BilgeAdamProject.Entities.Entities;
using BilgeAdamProject.Repositories.Interfaces;
using BilgeAdamProject.Services.Interfaces;

namespace BilgeAdamProject.Services.Concrete;

public class AuthorManager : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;
    public AuthorManager(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task AddOneAuthorAsync(AuthorDtoForInsertion authorDtoForInsertion)
    {
        //null kontrolü yap
        var author = _mapper.Map<Author>(authorDtoForInsertion);
        await _authorRepository.AddAsync(author);
    }
}

