using System;
using System.Data;
using InternetMarketBackEnd.Core.Infrastructure.Data;
using NHibernate;

namespace InternetMarketBackEnd.Infra.Data.NHibernate
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISession _session;
        public ISession CurrentSession { get { return _session; } }

        private ITransaction _transaction;

        public UnitOfWork()
        {
            OpenSession();
        }

        private void OpenSession()
        {
            if(_session == null || !_session.IsConnected)
            {
                if (_session != null)
                    _session.Dispose();
                _session = NHSessionFactorySingleton.SessionFactory.OpenSession();
            }
        }


        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if(_transaction == null || !_transaction.IsActive)
            {
                if (_transaction != null)
                    _transaction.Dispose();
                _transaction = _session.BeginTransaction(isolationLevel);
            }
        }

        public void Commit()
        {
            try
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
            }
        }
        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            if(_transaction != null)
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
            }
            GC.SuppressFinalize(this);
        }

    }
}
