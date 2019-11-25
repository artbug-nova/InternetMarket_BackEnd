using InternetMarketBackEnd.Application.Interfaces;
using InternetMarketBackEnd.Domain.Entity;
using InternetMarketBackEnd.Domain.Repository;
using InternetMarketBackEnd.Domain.Services.Common;

using System;

namespace InternetMarketBackEnd.Domain.Services
{
    public class OrderService : Service<Order>, IOrderAppService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository repository) : base(repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");
            _orderRepository = repository;
        }
    }
}
