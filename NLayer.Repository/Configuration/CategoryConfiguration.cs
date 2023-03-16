using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Model;

namespace NLayer.Repository.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category> // Dışarıdan erişmeyi düşünmüyoruz şuanda
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(50);

            builder.ToTable("Categories"); // Tablo adı verilebilir.
        }
    }
}
