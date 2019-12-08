﻿using InternetMarketBackEnd.Core.Domain.Entity;
using InternetMarketBackEnd.Core.Domain.Service;
using InternetMarketBackEnd.Core.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternetMarketBackEnd.Application.Interfaces
{
    public interface IAppService<TEntity> : IWriteOnlyService<TEntity> where TEntity: IAggregateRoot, new()
    {
        TEntity FindBy(ISpecification<TEntity> spec, bool @readonly = false);
        IQueryable<TEntity> FilterBy(ISpecification<TEntity> spec, bool @readonly = false);
        IQueryable<TEntity> GetAll(bool @readonly = false);
        TEntity GetById(long id, bool @readonly = false);

    }
}
