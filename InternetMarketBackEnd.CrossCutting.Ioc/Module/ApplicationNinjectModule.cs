using InternetMarketBackEnd.Application.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;



namespace InternetMarketBackEnd.CrossCutting.Ioc.Module
{
    class ApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IOrderAppService>.To<>();
        }
    }
}
