using InternetMarketBackEnd.Core.Domain;
using InternetMarketBackEnd.Domain.Entity.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Domain.Entity
{
    public class Order : ISelfValidation
    {
        public Order() { }
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        public ValidationResult ValidationResult { get; private set; }
        public bool IsValid
        {
            get{
                var valid = new OrderIsValidValidation();
                ValidationResult = valid.Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
