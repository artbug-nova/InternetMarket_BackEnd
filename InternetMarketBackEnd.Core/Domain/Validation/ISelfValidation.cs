using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Core.Domain
{
    public interface ISelfValidation
    {
        bool IsValid { get; }
    }
}
