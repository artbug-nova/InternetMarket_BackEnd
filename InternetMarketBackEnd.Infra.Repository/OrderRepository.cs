using InternetMarketBackEnd.Core.Infrastructure.Data;
using InternetMarketBackEnd.Domain.Entity;
using InternetMarketBackEnd.Domain.Repository;
using InternetMarketBackEnd.Infra.Data.Config;
using InternetMarketBackEnd.Infra.Repository.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternetMarketBackEnd.Infra.Repository
{
    public class OrderRepository: Repository<Order>, IOrderRepository
    {
        private readonly IDbContext dbContext;

        public OrderRepository(IDbContext dbContext) : base(dbContext) {
            this.dbContext = dbContext;
        }
    }
}
