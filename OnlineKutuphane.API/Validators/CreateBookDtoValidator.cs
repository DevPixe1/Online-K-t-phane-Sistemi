using FluentValidation;
using OnlineKutuphane.Core.Dtos;

public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
{
    //API'ye kitap eklerken gönderilen verilerin doğruluğunu kontrol ede ve kurallarını tanımlar
    public CreateBookDtoValidator()
    {
        //Kitap başlığı boş olamaz
        RuleFor(x => x.Title).NotEmpty().WithMessage("Kitap başlığı zorunludur.");

        //Yazar adı boş olamaz
        RuleFor(x => x.Author).NotEmpty().WithMessage("Yazar adı zorunludur.");

        //Yayın yılı aralığı belirler
        RuleFor(x => x.PublishedYear).InclusiveBetween(1500, DateTime.Now.Year);

        //Geçerli bir kategori seçilmelidir (0'dan büyük olmalı)
        RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Kategori seçilmelidir.");
    }
}
