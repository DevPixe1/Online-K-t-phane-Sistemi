using Microsoft.EntityFrameworkCore;
using OnlineKutuphane.Core;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace OnlineKutuphane.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } // Kitap tablosu

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
