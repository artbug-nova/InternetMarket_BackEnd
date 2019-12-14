using InternetMarketBackEnd.Core.Infrastructure.Data;
using InternetMarketBackEnd.Domain.Entity;
using InternetMarketBackEnd.Infra.Repository.Common;

namespace InternetMarketBackEnd.Infra.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IDbContext _dbContext;

        public UserRepository(IDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
