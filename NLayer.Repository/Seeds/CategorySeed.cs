using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Model;

namespace NLayer.Repository.Seeds
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Category c = new(); category tipinde oluşturabiliriz. Eski kullanım => Category c = new Category();
            builder.HasData( // Id sadece seed data da verilir. Uygulama genelinde repository'de verilmez.
                new Category { Id = 2, Name = "Kalemler" }, 
                new Category { Id = 1, Name = "Kitaplar" }, 
                new Category { Id = 3, Name = "Defterler" }
                ); 
            

        }
    }
}
