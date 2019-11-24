using Autofac;
using InternetMarketBackEnd.Application.Interfaces;
using InternetMarketBackEnd.Domain.Services;

namespace InternetMarketBackEnd.CrossCutting.Ioc.Module
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderService>().As<IOrderAppService>().InstancePerLifetimeScope();
        }
    }
}
