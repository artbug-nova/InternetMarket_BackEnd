using InternetMarketBackEnd.Core.Infrastructure.Data;

namespace InternetMarketBackEnd.Infra.Data.NHibernate
{
    public interface IUnitOfWork<TContext> where TContext: IDbContext, new()
    {
        void BeginTransaction();
        void SaveChanges();
        void Rollback();
    }
}