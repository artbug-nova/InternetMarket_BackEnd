using System;
using System.Data;
using NHibernate;


namespace InternetMarketBackEnd.Core.Infrastructure.Data
{
    public interface IUnitOfWork: IDisposable
    {
        ISession CurrentSession { get; }

        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        void Commit();

        void Rollback();
    }
}
