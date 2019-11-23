using FluentNHibernate.Mapping;
using InternetMarketBackEnd.Core.Helpers;
using InternetMarketBackEnd.Domain.Entity;
using System;

namespace InternetMarketBackEnd.Infra.Data.Mapping
{
    public class OrderMap: ClassMap<Order>
    {
        public OrderMap()
        {
            Schema(EnumSchema.HRM.ToString());
            Table(typeof(Order).Name);
            Id(x => x.OrderId).GeneratedBy.Identity();
            Map(x => x.Price);
        }
    }
}
