using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Core.Domain
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Valid(TEntity entity);
    }
}
