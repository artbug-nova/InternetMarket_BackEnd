using InternetMarketBackEnd.CrossCutting.Config.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Infra.Data
{
    public class MarketContext : BaseDBContext
    {
        public MarketContext(DbContextOptions options) : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
