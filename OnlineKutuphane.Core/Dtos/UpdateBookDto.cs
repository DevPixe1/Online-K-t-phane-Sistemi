namespace OnlineKutuphane.Core.Dtos
{
    public class UpdateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public int CategoryId { get; set; }
    }
}
