using InternetMarketBackEnd.Core.Domain.Entity;
using InternetMarketBackEnd.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Application.Interfaces
{
    public interface IAppService<TEntity> : IWriteOnlyService<TEntity> where TEntity:class, new()
    {
    }
}
