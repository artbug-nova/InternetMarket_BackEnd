using InternetMarketBackEnd.Core.Domain.Entity;
using InternetMarketBackEnd.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarketBackEnd.Infra.Repository.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity<long>
    {

        private readonly IDbContext DbContext;
        private readonly DbSet<TEntity> dbSet;

        public Repository(IDbContext dbContext)
        {
            this.DbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }

        public async Task<IQueryable<TEntity>> GetAsync()
            => await Task.FromResult(dbSet);

        public async Task AddAsync(TEntity entity)
            => await dbSet.AddAsync(entity);

        public async Task UpdateAsync(TEntity entity)
            => await Task.FromResult(dbSet.Update(entity));

        public async Task DeleteAsync(TEntity entity)
            => await Task.FromResult(dbSet.Remove(entity));

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await DbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<TEntity> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
