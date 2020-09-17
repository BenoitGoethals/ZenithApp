using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithApp.model;

namespace ZenithApp.Data
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(f => f.Id)
                 .ValueGeneratedOnAdd(); ;
            builder.Property(s => s.Name).HasColumnName(nameof(Product.Name)).HasMaxLength(50).IsRequired();
            builder.Property(s => s.Price).HasColumnName(nameof(Product.Price)).IsRequired();
            builder.Property(s => s.VatPercentage).HasColumnName(nameof(Product.VatPercentage)).IsRequired();
            builder.Property(s => s.Image).HasColumnName(nameof(Product.Image));
            builder.Property(s => s.Code).HasColumnName(nameof(Product.Code)).HasMaxLength(50).IsRequired();
            builder.Property(s => s.Description).HasColumnName(nameof(Product.Description)).HasMaxLength(150);


            builder.HasOne(s => s.TypeProduct).WithMany().OnDelete(DeleteBehavior.Restrict);



        }
    }
}
