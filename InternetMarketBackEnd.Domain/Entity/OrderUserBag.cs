using InternetMarketBackEnd.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Domain.Entity
{
    public class OrderUserBag: BaseEntity<long>
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public long UserBagId { get; set; }
        public UserBag UserBag { get; set; }
    }
}
