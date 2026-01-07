using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionPronia.Domain.Entities;


namespace OnionPronia.Persistence.Configuration
{
    internal class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
    {
        void IEntityTypeConfiguration<ProductColor>.Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder .HasKey(pc => new { pc.ProductId, pc.ColorId });
        }
    }
}
