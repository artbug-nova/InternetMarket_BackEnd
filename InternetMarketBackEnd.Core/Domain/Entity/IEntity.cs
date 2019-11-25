using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Core.Domain.Entity
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
