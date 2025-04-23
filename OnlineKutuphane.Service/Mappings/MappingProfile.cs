using AutoMapper;
using OnlineKutuphane.Core;
using OnlineKutuphane.Core.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : ""));

        CreateMap<CreateBookDto, Book>();
        CreateMap<UpdateBookDto, Book>();

    }
}
