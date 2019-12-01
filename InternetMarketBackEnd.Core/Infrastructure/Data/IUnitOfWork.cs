using System;
using System.Data;


namespace InternetMarketBackEnd.Core.Infrastructure.Data
{
    public interface IUnitOfWork<TContext>: IDisposable where TContext: IDbContext, new()
    {
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        void SaveChanges();

        void Rollback();
    }
}
