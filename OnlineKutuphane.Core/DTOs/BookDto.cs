namespace OnlineKutuphane.Core.DTOs
{
    // API'nin dışarıya göstereceği veri yapısı
    public class BookDto
    {
        public int Id { get; set; } // Güncelleme ve silme için gerekli
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
    }
}
