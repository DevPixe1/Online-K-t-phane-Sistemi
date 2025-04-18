﻿namespace OnlineKutuphane.Core.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Year { get; set; }

        public string CategoryName { get; set; } = string.Empty;
    }
}
