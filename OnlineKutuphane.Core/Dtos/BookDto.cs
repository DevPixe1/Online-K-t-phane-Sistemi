namespace OnlineKutuphane.Core.Dtos
{
    //API'den kitap bilgilerini istemcilere dönerken kullanılan veri transfer nesnesi (DTO). Sadece gerekli ve gösterilecek bilgileri içerir
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;
    }
}
