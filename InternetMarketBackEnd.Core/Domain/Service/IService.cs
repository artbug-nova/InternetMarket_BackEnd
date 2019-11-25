using InternetMarketBackEnd.Core.Domain.Entity;
using InternetMarketBackEnd.Core.Domain.Specification;
using System.Linq;

namespace InternetMarketBackEnd.Core.Domain.Service
{
    public interface IService<TEntity> : IWriteOnlyService<TEntity> where TEntity: IAggregateRoot, new()
    {
        TEntity FindBy(ISpecification<TEntity> spec, bool @readonly = false);
        IQueryable<TEntity> FilterBy(ISpecification<TEntity> spec, bool @readonly = false);
        IQueryable<TEntity> GetAll(bool @readonly = false);
        TEntity GetById(object id, bool @readonly = false);
    }
}
