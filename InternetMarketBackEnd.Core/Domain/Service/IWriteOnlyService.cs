using InternetMarketBackEnd.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Core.Domain.Service
{
    public interface IWriteOnlyService<TEntity>:IDisposable where TEntity: IAggregateRoot, new()
    {
        ValidationResult Add(TEntity entity);
        ValidationResult Add(IEnumerable<TEntity> entities);
        ValidationResult Update(TEntity entity);
        ValidationResult Update(IEnumerable<TEntity> entities);
        ValidationResult Remove(TEntity entity);
        ValidationResult Remove(IEnumerable<TEntity> entities);
    }
}
