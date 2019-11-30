using InternetMarketBackEnd.Core.Domain.Entity;
using InternetMarketBackEnd.Core.Domain.Repository;
using InternetMarketBackEnd.Core.Infrastructure.Data;
using InternetMarketBackEnd.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarketBackEnd.Infra.Repository.Common
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IList<Order>> GetOrderAsync(int id);
    }
}
