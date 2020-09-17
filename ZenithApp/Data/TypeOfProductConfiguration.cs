using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.Collections.Generic;
using ZenithApp.model;

namespace ZenithApp.Data
{
    public class TypeOfProductConfiguration : IEntityTypeConfiguration<TypeProduct>
    {
        public void Configure(EntityTypeBuilder<TypeProduct> builder)
        {
            builder.Property(f => f.Id)
                 .ValueGeneratedOnAdd(); ;
            builder.Property(s => s.Name).HasColumnName(nameof(TypeProduct.Name)).IsRequired();
            builder.HasData(
                new List<TypeProduct>()
                {

                    new TypeProduct(1,"Drank"),
                    new TypeProduct(2,"Chips"),
                    new TypeProduct(3,"other"),

                }

                );
        }
    }
}
