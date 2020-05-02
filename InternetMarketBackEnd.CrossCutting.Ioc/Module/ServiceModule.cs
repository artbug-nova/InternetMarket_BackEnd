using Autofac;
using InternetMarketBackEnd.Application.Interfaces;
using InternetMarketBackEnd.Domain.Services;

namespace InternetMarketBackEnd.CrossCutting.Ioc.Module
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderAppService>().As<IOrderAppService>();
            builder.RegisterType<ProductAppService>().As<IProductAppService>();
            builder.RegisterType<UserAppService>().As<IUserAppService>();
            builder.RegisterType<CategoryAppService>().As<ICategoryAppService>();
        }
    }
}
