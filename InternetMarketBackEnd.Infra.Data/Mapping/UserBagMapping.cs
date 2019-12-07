using InternetMarketBackEnd.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Infra.Data.Mapping
{
    public class UserBagMapping : IEntityTypeConfiguration<UserBag>
    {
        public void Configure(EntityTypeBuilder<UserBag> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.UserId);

        }
    }
}
