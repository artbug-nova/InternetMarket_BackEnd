using InternetMarketBackEnd.Core.Infrastructure.Data;

namespace InternetMarketBackEnd.Infra.Data.Config
{
    public interface IUnitOfWork<TContext> where TContext: IDbContext
    {
        public IDbContext MarketContext { get; }
        void BeginTransaction();
        void SaveChanges();
        void Rollback();
    }
}