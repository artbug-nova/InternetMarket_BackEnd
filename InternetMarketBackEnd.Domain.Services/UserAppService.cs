using InternetMarketBackEnd.Application.Interfaces;
using InternetMarketBackEnd.Domain.Entity;
using InternetMarketBackEnd.Domain.Services.Common;
using InternetMarketBackEnd.Infra.Repository.Common;
using System;

namespace InternetMarketBackEnd.Domain.Services
{
    public class UserAppService : Service<User>, IUserAppService
    {
        private readonly IUserRepository _userRepository;
        public UserAppService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException("repository");
        }

        public User GetUserWithRole(User user)
        {
            return this._userRepository.GetUserWithRole(user);
        }
    }
}
