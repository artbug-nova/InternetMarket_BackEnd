using InternetMarketBackEnd.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarketBackEnd.Core.Domain.Service
{
    public interface IWriteOnlyService<TEntity>:IDisposable where TEntity: IAggregateRoot, new()
    {
        ValidationResult Add(TEntity entity);
        Task<ValidationResult> AddAsync(TEntity entity);
        ValidationResult Add(IEnumerable<TEntity> entities);
        ValidationResult Update(TEntity entity);
        Task<ValidationResult> UpdateAsync(TEntity entity);
        
        ValidationResult Update(IEnumerable<TEntity> entities);
        ValidationResult Remove(TEntity entity);
        Task<ValidationResult> RemoveAsync(TEntity entity);
        ValidationResult Remove(IEnumerable<TEntity> entities);
    }
}
