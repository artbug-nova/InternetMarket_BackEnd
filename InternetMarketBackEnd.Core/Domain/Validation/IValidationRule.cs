using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Core.Domain
{
    public interface IValidationRule<in TEntity>
    {
        string ErrorMessage { get; }
        bool Valid(TEntity entity);
    }
}
