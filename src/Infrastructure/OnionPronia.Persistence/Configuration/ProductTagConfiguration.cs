using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Persistence.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name) 
                  .IsRequired()
                  .HasMaxLength(200);
            builder.Property(p => p.SKU) 
                  .IsRequired()
                  .HasMaxLength(100);
          builder.Property(p => p.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
          builder.Property(p => p.Description)
                  .IsRequired()
                  .HasMaxLength(5000);
         builder.Property(p => p.SKU)
                  .HasColumnType( "char(10)" );
         builder.HasIndex(p => p.SKU)
                  .IsUnique();

        }
    }
}
