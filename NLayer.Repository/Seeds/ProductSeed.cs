using Microsoft.EntityFrameworkCore;
using NLayer.Core.Model;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name= "KALEM 1",
                    CategoryId = 1,
                    Price = 100,
                    Stock = 20,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 2,
                    Name = "KALEM 2",
                    CategoryId = 1,
                    Price = 200,
                    Stock = 30,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 3,
                    Name = "KALEM 3",
                    CategoryId = 1,
                    Price = 600,
                    Stock = 60,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 4,
                    Name = "KİTAP 1",
                    CategoryId = 2,
                    Price = 100,
                    Stock = 20,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Id = 5,
                    Name = "KİTAP 2",
                    CategoryId = 2,
                    Price = 5900,
                    Stock = 3200,
                    CreatedDate = DateTime.Now
                 }
               );
        }
    }
}
