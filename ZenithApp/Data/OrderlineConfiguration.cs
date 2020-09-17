using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithApp.model;

namespace ZenithApp.Data
{
    public class OrderlineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.Property(f => f.Id)
               .ValueGeneratedOnAdd(); ;
            builder.Property(s => s.Count).HasColumnName(nameof(OrderLine.Count)).HasMaxLength(50).IsRequired();



        }
    }
}
