using InternetMarketBackEnd.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Domain.Entity
{
    public class UserBag : BaseEntity<long>
    {
        public long UserId { get; set; }
        public ICollection<OrderUserBag> OrderUserBags { get; set; }
    }
}
