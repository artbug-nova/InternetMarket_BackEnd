using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Application.Interfaces
{
    public interface IResult
    {
        int Code { get; set; }
        string Message { get; set; }
        Exception Exception { get; set; }
    }
}
