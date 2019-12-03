using InternetMarketBackEnd.Core.Infrastructure.Data;
using System;
using System.Data;



namespace InternetMarketBackEnd.Infra.Data.NHibernate
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable
        where TContext:IDbContext, new()
    {
        private readonly IDbContext _dbContext;
        private bool _disposed;
        public UnitOfWork()
        {
           
        }


        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            /*if(_transaction == null || !_transaction.IsActive)
            {
                if (_transaction != null)
                    _transaction.Dispose();
                _transaction = _session.BeginTransaction(isolationLevel);
            }*/
        }

        public void Commit()
        {
            /*try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }*/
        }
        public void Rollback()
        {
            /*try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Dispose();
            }*/
        }

        public void Dispose()
        {
            /*if(_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
            if (_session != null)
            {
                _session.Flush();
                _session.Close();
                _session.Dispose();
                _session = null;
            }*/
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
