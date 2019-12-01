using InternetMarketBackEnd.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Application.Models
{
    public class Result : IResult
    {
        public int Code { get; set ; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
