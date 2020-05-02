using InternetMarketBackEnd.Application.Interfaces;
using InternetMarketBackEnd.Domain.Entity;
using InternetMarketBackEnd.Domain.Services.Common;
using InternetMarketBackEnd.Infra.Repository.Common;
using System;

namespace InternetMarketBackEnd.Domain.Services
{
    public class ProductAppService : Service<Product>, IProductAppService
    {
        public ProductAppService(IProductRepository productRepository) : base(productRepository) { }
    }
}
