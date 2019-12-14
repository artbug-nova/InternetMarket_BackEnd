using InternetMarketBackEnd.Core.Infrastructure.Data;
using InternetMarketBackEnd.Domain.Entity;
using InternetMarketBackEnd.Infra.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace InternetMarketBackEnd.Infra.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IDbContext _dbContext;

        public UserRepository(IDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public User GetUserWithRole(User user)
        {
            return this.dbSet.Include(s => s.UserRole).Where(s => s.Email == user.Email && s.Password == s.Password).SingleOrDefault();
        }
    }
}
