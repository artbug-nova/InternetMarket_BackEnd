using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Shared.Exceptions
{
    public abstract class DomainException : Exception
    {
        public DomainException(string Message) : base(Message) { }
    }
}
