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
            if (userRepository == null)
                throw new ArgumentNullException("repository");
            _userRepository = userRepository;
        }

        public User GetUserWithRole(User user)
        {
            return this._userRepository.GetUserWithRole(user);
        }
    }
}
