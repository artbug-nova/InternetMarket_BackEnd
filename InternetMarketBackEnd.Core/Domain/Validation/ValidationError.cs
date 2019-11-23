using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Core.Domain
{
    public class ValidationError
    {
        public string Message { get; set; }
        public ValidationError(string message)
        {
            Message = message;
        }
    }
}
