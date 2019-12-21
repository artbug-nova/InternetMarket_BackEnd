using InternetMarketBackEnd.Application.Interfaces;
using InternetMarketBackEnd.Domain.Entity;
using InternetMarketBackEnd.Domain.Services.Common;
using InternetMarketBackEnd.Infra.Repository.Common;
using System;

namespace InternetMarketBackEnd.Domain.Services
{
    public class OrderAppService : Service<Order>, IOrderAppService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderAppService(IOrderRepository repository) : base(repository)
        {
            _orderRepository = repository ?? throw new ArgumentNullException("repository");
        }
    }
}
