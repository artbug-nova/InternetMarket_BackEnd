using InternetMarketBackEnd.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Domain.Entity
{
    public class UserRole : BaseEntity<Int64>
    {
        String _userRoleName;

        public string UserRoleName { get => _userRoleName; set => _userRoleName = value; }
        public ICollection<User> Users { get; set; }
    }
}
