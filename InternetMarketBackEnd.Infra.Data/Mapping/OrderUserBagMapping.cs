using InternetMarketBackEnd.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Infra.Data.Mapping
{
    public class OrderUserBagMapping : IEntityTypeConfiguration<OrderUserBag>
    {
        public void Configure(EntityTypeBuilder<OrderUserBag> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(bc => bc.Order)
                .WithMany(bc => bc.OrderUserBags)
                .HasForeignKey(bc => bc.Id);
            builder.HasOne(bc => bc.UserBag)
                .WithMany(bc => bc.OrderUserBags)
                .HasForeignKey(bc => bc.Id);
        }
    }
}
