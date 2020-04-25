using InternetMarketBackEnd.Core.Domain.Entity;
using InternetMarketBackEnd.Core.Domain.Specification;
using System.Linq;
using System.Threading.Tasks;

namespace InternetMarketBackEnd.Core.Domain.Service
{
    public interface IService<TEntity> : IWriteOnlyService<TEntity> where TEntity: IAggregateRoot, new()
    {
        Task<TEntity> FindBy(ISpecification<TEntity> spec, bool @readonly = false);
        Task<IQueryable<TEntity>> FilterBy(ISpecification<TEntity> spec, bool @readonly = false);
        Task<IQueryable<TEntity>> GetAll(bool @readonly = false);
        Task<TEntity> GetById(long id, bool @readonly = false);
    }
}
