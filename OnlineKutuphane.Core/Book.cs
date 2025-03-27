using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineKutuphane.Core
{
    public class Book
    {
        public int Id { get; set; }  // Kitap ID (Primary Key)
        public string Title { get; set; }  // Kitap Adı
        public string Author { get; set; }  // Yazar
        public int PublishedYear { get; set; }  // Yayınlanma Yılı
    }
}
