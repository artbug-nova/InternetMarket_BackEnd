using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using InternetMarketBackEnd.Infra.Repository;
using InternetMarketBackEnd.Infra.Repository.Common;

namespace InternetMarketBackEnd.CrossCutting.Ioc.Module
{
    public class RepositoryModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
        }
    }
}
