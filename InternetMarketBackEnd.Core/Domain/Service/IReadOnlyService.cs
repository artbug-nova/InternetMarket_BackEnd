using InternetMarketBackEnd.Core.Domain.Entity;
using InternetMarketBackEnd.Core.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternetMarketBackEnd.Core.Domain.Service
{
    public interface IReadOnlyService<TEntity> :IDisposable where TEntity: class, new()
    {
        TEntity FindBy(ISpecification<TEntity> spec);
        IQueryable<TEntity> FilterBy(ISpecification<TEntity> spec);
        IQueryable<TEntity> GetAll();
        TEntity GetById(object id);

    }
}
