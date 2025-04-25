using Microsoft.EntityFrameworkCore;
using OnlineKutuphane.Core;

namespace OnlineKutuphane.Data
{
    //Uygulamanın veritabanı ile olan bağlantısını sağlar
    public class AppDbContext : DbContext
    {
        //Bağlantı ayarlarını options üzerinden alır (Program.cs'de tanımlanır)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Book ve Category tablolarını temsil eden DbSet'ler
        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        //Veritabanı modeli oluşturulurken çalışır (örnek kategori verileri/ seed data)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Roman" },
                new Category { Id = 2, Name = "Bilim" },
                new Category { Id = 3, Name = "Tarih" }
            );
        }
    }
}
