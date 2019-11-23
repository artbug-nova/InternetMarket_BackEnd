using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace InternetMarketBackEnd.Core.Domain.Specification
{
    public abstract class SpecificationBase<T> : ISpecification<T>
    {
        private Func<T, bool> _compiledExpression;

        private Func<T, bool> CompiledExpression
        {
            get { return _compiledExpression ?? (_compiledExpression = SpecExpression.Compile()); }
        }

        public virtual Expression<Func<T, bool>> SpecExpression { get; }

        public virtual bool IsSatisfiedBy(T obj)
        {
            return CompiledExpression(obj);
        }
    }
}
