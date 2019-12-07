using InternetMarketBackEnd.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.CrossCutting.Config.Config
{
    public class BaseDBContext : DbContext, IDbContext
    {
        public int? CurrentUserId { get; private set; }
        public BaseDBContext(DbContextOptions options):base(options)
        {
            
        }
        public new DbSet<TEntity> Set<TEntity>() where TEntity: class
        {
            return base.Set<TEntity>();
        }
        
    }
}
