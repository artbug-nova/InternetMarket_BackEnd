using InternetMarketBackEnd.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Core.Domain.Repository
{
    public interface IWriteOnlyRepository<TEntity> : IDisposable where TEntity: IAggregateRoot, new()
    {
        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entity);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entity);
        void Remove(TEntity entity);
        void Remove(IEnumerable<TEntity> entity);
    }
}
