using FluentValidation;
using OnlineKutuphane.Core.Dtos;

public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
{
    public CreateBookDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Başlık boş olamaz.");

        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("Yazar adı boş olamaz.");

        RuleFor(x => x.PublishedYear)
            .GreaterThan(1450).WithMessage("Yayın yılı 1450'den büyük olmalıdır.")
            .LessThanOrEqualTo(DateTime.Now.Year).WithMessage($"Yayın yılı {DateTime.Now.Year} yılına kadar olabilir.");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Kategori seçilmelidir.");
    }
}
