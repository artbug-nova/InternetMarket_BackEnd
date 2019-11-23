using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Core.Application
{
    public interface IAppService<TEntity> : IWriteOnlyAppService<TEntity>, IDisposable where TEntity: class, new()
    {
    }
}
