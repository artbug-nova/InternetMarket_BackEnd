using InternetMarketBackEnd.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Infra.Data.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.ProductId);
            builder.Property(s => s.Price).IsRequired();
            builder.HasOne(c => c.Product)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.ProductId).IsRequired();
        }
    }
}
