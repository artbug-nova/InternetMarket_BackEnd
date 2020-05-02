using InternetMarketBackEnd.Core.Infrastructure.Data;
using InternetMarketBackEnd.Domain.Entity;
using InternetMarketBackEnd.Infra.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Infra.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbContext dbContext) : base(dbContext) { }

    }
}
