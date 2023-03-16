using Microsoft.EntityFrameworkCore;
using NLayer.Core.Model;
using System.Reflection;

namespace NLayer.Repository
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base (options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; } // ProductFeatures'i içerisine almak BestPractice'dir. Yani içerisinde tanımlanmak zorundadır.
        public DbSet<ProductFeature> ProductFeatures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Tamamı için yapılır. 22.Ders 17:00

            // Best practice açısından burasının kirletilmemesi gerekir!! Sadece denemek amaçlı yapılmıştır.
            modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature()
            {
                Id = 1,
                Color = "Kırmızı",
                Height = 120,
                Width = 200,
                ProductId = 1,
            },
            new ProductFeature()
            {
                Id = 2,
                Color = "Mavi",
                Height = 60,
                Width = 300,
                ProductId = 2,
            }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
