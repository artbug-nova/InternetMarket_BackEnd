using InternetMarketBackEnd.CrossCutting.Config.Config;
using InternetMarketBackEnd.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Infra.Data
{
    public class MarketContext : BaseDBContext
    {
        public MarketContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderMapping());
            builder.ApplyConfiguration(new ProductMapping());
            builder.ApplyConfiguration(new OrderUserBagMapping());
        }
    }
}
