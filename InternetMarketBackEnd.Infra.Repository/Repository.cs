﻿using InternetMarketBackEnd.Core.Domain.Entity;
using InternetMarketBackEnd.Core.Infrastructure.Data;
using InternetMarketBackEnd.Infra.Data.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarketBackEnd.Infra.Repository.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity<long>, new()
    {
        private readonly IDbContext DbContext;
        private readonly DbSet<TEntity> dbSet;

        public Repository(IDbContext dbContext)
        {
            this.DbContext = dbContext;
            this.dbSet = DbContext.Set<TEntity>();
        }

        public async Task<IQueryable<TEntity>> GetAsync()
            => await Task.FromResult(dbSet);

        public async Task AddAsync(TEntity entity)
        {
            dbSet.Add(entity);
            DbContext.SaveChanges();
        }
        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
            DbContext.SaveChanges();
        }

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
                throw new Exception(e.Message);
            }
        }

        public Task<TEntity> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            return dbSet.SingleOrDefault(s => s.Id == id);
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }
    }
}
