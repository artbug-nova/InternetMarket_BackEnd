using InternetMarketBackEnd.Core.Infrastructure.Data;
using InternetMarketBackEnd.Domain.Entity;
using InternetMarketBackEnd.Domain.Repository;
using InternetMarketBackEnd.Infra.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Infra.Repository
{
    public class OrderRepository: Repository<Order> 
    {
        private readonly IDbContext dbContext;
        public OrderRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
