using Autofac;
using InternetMarketBackEnd.Core.Infrastructure.Data;
using InternetMarketBackEnd.Infra.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.CrossCutting.Ioc.Module
{
    public class InfrastructureModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MarketContext>().As<IDbContext>().InstancePerLifetimeScope();
        }
    }
}
