using InternetMarketBackEnd.Core.Infrastructure.Data;
using InternetMarketBackEnd.Infra.Data.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;



namespace InternetMarketBackEnd.Infra.Data.Config
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable
        where TContext:IDbContext
    {
        public IDbContext _marketContext;
        private IDbContextTransaction _transaction;
        private bool _disposed;

        //public IUnitOfWork<TContext> MarketContext { get { return _marketContext; } private set ; }

        
        public IDbContext MarketContext { get => _marketContext; }

        public UnitOfWork(IDbContext marketContext)
        {
            _marketContext = marketContext;
        }

        public void BeginTransaction()
        {
            if(_transaction == null)
            {
                
                if (_transaction != null)
                    _transaction.Dispose();
                _transaction = ((DbContext)_marketContext).Database.BeginTransaction();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null)
                    _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void SaveChanges()
        {
            if (_marketContext != null)
            {
                _marketContext.SaveChanges();
            }
        }
        public void Dispose()
        {
            if(_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
            if(_marketContext != null)
            {
                _marketContext.Dispose();
                _marketContext = null;
            }
            GC.SuppressFinalize(this);
        }

    }
}
