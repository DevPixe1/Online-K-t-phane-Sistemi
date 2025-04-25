namespace OnlineKutuphane.Core.Dtos
{
    //Var olan bir kitabı güncellemek için kullanılan veri transfer nesnesi (DTO)
    public class UpdateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public int CategoryId { get; set; }
    }
}
