using FluentValidation;
using OnlineKutuphane.Core.Dtos;

public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
{
    public CreateBookDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Kitap başlığı zorunludur.");
        RuleFor(x => x.Author).NotEmpty().WithMessage("Yazar adı zorunludur.");
        RuleFor(x => x.PublishedYear).InclusiveBetween(1500, DateTime.Now.Year);
        RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Kategori seçilmelidir.");
    }
}
