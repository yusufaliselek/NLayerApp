using Microsoft.EntityFrameworkCore;
using NLayer.Core;
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
