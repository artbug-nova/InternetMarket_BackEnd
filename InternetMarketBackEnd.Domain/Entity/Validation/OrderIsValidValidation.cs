using InternetMarketBackEnd.Core.Domain;
using InternetMarketBackEnd.Core.Domain.Validation;
using InternetMarketBackEnd.Domain.Entity.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Domain.Entity.Validation
{
    class OrderIsValidValidation : Validation<Order>
    {
        public OrderIsValidValidation()
        {
            base.AddRule(new ValidationRule<Order>(new OrderPriceIsRequired(), ValidationMessage.TitleIsRequired));
        }
    }
}
