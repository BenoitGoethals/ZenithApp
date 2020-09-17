using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithApp.model;

namespace ZenithApp.Data
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.Gsm).HasColumnName(nameof(Basket.Gsm)).IsRequired();
            builder.Property(s => s.Email).HasColumnName(nameof(Basket.Email)).IsRequired();
            builder.Property(s => s.DateTimeCreated).HasColumnName(nameof(Basket.DateTimeCreated)).IsRequired();
            builder.Property(s => s.Collected).HasColumnName(nameof(Basket.Collected)).IsRequired();
            builder.Property(s => s.Payed).HasColumnName(nameof(Basket.Payed)).IsRequired();
            builder.HasMany<OrderLine>(s => s.Lines).WithOne().HasForeignKey(t => t.BasketId).OnDelete(DeleteBehavior.Cascade); ;
        }
    }
}
