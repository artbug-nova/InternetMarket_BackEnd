using InternetMarketBackEnd.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Core.Application
{
    public interface IWriteOnlyAppService<TEntity> where TEntity: class, new()
    {
        ValidationResult Create(TEntity entity);
    }
}
