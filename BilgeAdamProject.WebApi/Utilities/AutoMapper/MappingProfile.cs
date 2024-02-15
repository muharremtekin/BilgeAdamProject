using AutoMapper;
using BilgeAdamProject.Entities.DataTransferObjects;
using BilgeAdamProject.Entities.Entities;

namespace BilgeAdamProject.WebApi.Utilities.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // eklenecek
        CreateMap<BookDtoForInsertion, Book>()
            .ReverseMap();

        CreateMap<Book, BookDto>()
            .ReverseMap();
    }
}

