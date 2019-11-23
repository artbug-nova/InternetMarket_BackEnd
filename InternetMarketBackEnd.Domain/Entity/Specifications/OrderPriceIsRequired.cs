using InternetMarketBackEnd.Core.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace InternetMarketBackEnd.Domain.Entity.Specifications
{
    public class OrderPriceIsRequired : ISpecification<Order>
    {
        public Expression<Func<Order, bool>> SpecExpression => throw new NotImplementedException();

        public bool IsSatisfiedBy(Order obj)
        {
            return obj.Price > 0;
        }
    }
}
