﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineKutuphane.Core
{
    //Amaç: Kütüphane sisteminde her bir kitabı temsil eder. Kitap bilgilerini tutar ve kategori ile ilişkilidir.
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public int PublishedYear { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
