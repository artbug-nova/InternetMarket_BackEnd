using System;
using System.Linq.Expressions;

namespace InternetMarketBackEnd.Core.Domain.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> SpecExpression { get; }
        bool IsSatisfiedBy(T obj);
    }
}
