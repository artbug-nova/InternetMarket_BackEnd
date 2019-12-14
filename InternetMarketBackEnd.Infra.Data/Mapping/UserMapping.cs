using InternetMarketBackEnd.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Infra.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name);
            builder.Property(s => s.Email);
            builder.Property(s => s.Password);
            builder.HasOne(s => s.UserRole)
                .WithMany(s => s.Users)
                .HasForeignKey(s => s.UserRoleId);
        }
    }
}
