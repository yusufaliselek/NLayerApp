using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x=> x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Stock).IsRequired();

            builder.Property(x=> x.Price).IsRequired().HasColumnType("decimal(18,2)"); // 18 karakter toplam virgülün sağı 2 | solu 16

            builder.ToTable("Products");

            // Foreign Key'i products içerisinde açık açık belirtmez isek Örn: Category__Id şeklinde bunu HasForeignKey şeklinde tanımlamamız gerekir.
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId); // FluentAPI bire-çok ilişki.
        }
    }
}
