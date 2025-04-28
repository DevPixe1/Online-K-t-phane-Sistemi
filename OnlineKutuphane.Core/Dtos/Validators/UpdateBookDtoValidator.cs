using FluentValidation;
using OnlineKutuphane.Core.Dtos;

namespace OnlineKutuphane.Core.Dtos.Validators
{
    public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Kitap başlığı boş olamaz.");

            RuleFor(x => x.Author)
                .NotEmpty()
                .WithMessage("Yazar adı boş olamaz.");

            RuleFor(x => x.PublishedYear)
                .InclusiveBetween(1500, DateTime.Now.Year)
                .WithMessage($"Yayın yılı 1500 ile {DateTime.Now.Year} arasında olmalıdır.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0)
                .WithMessage("Kategori seçilmelidir.");
        }
    }
}
