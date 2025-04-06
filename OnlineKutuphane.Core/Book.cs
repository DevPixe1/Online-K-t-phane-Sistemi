using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineKutuphane.Core
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kitap başlığı zorunludur.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yazar adı zorunludur.")]
        public string Author { get; set; } = string.Empty;

        public int PublishedYear { get; set; }
    }
}
