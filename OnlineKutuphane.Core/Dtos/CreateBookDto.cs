namespace OnlineKutuphane.Core.Dtos
{
    // Yeni kitap oluşturmak için kullanılan DTO
    public class CreateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public int CategoryId { get; set; }
    }
}
