namespace OnlineKutuphane.Core.Dtos
{
    using System.ComponentModel.DataAnnotations;

    //Yeni kitap oluşturmak için kullanılan veri transfer nesnesi (DTO)
    public class CreateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PublishedYear { get; set; }

        public int CategoryId { get; set; }

        // Validation kuralları
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Title))
                yield return new ValidationResult("Başlık boş olamaz.", new[] { nameof(Title) });

            if (string.IsNullOrWhiteSpace(Author))
                yield return new ValidationResult("Yazar adı boş olamaz.", new[] { nameof(Author) });

            if (PublishedYear < 1450 || PublishedYear > DateTime.Now.Year)
                yield return new ValidationResult("Yayın yılı geçersiz.", new[] { nameof(PublishedYear) });

            if (CategoryId <= 0)
                yield return new ValidationResult("Kategori seçilmelidir.", new[] { nameof(CategoryId) });
        }
    }
}
