using InternetMarketBackEnd.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarketBackEnd.Infra.Repository.Common
{
    public interface IRepository<TEntity> where TEntity: IAggregateRoot
    {
        Task<TEntity> GetAsync(int id);
        Task<IQueryable<TEntity>> GetAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}
