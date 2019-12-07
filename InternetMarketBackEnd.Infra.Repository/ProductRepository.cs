using InternetMarketBackEnd.Core.Infrastructure.Data;
using InternetMarketBackEnd.Domain.Entity;
using InternetMarketBackEnd.Infra.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Infra.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IDbContext dbContext;

        public ProductRepository(IDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
