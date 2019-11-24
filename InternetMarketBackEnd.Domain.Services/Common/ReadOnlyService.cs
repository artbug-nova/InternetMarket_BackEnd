using InternetMarketBackEnd.Core.Domain.Service;
using InternetMarketBackEnd.Core.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternetMarketBackEnd.Domain.Services.Common
{
    public class ReadOnlyService<TEntity> : IReadOnlyService<TEntity> where TEntity : class, new()
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FilterBy(ISpecification<TEntity> spec)
        {
            throw new NotImplementedException();
        }

        public TEntity FindBy(ISpecification<TEntity> spec)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
