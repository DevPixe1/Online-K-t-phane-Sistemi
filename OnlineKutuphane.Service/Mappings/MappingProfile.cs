using AutoMapper;
using OnlineKutuphane.Core;
using OnlineKutuphane.Core.Dtos;

public class MappingProfile : Profile
{
    //Nesneler arasında (örneğin DTO ile Entity arasında) otomatik dönüşüm sağlar,
    public MappingProfile()
    {
        //CategoryName alanı, Category varsa onun Name değeri ile eşleştirilir, yoksa boş string atanır
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : ""));

        //Book dönüşümünü yapar (Kitap eklerken kullanılır)
        CreateMap<CreateBookDto, Book>();

        //Book dönüşümünü yapar (Kitap güncellerken kullanılır)
        CreateMap<UpdateBookDto, Book>();

    }
}
