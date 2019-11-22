using InternetMarketBackEnd.Core.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Core.Domain
{
    public class ValidationRule<TEntity> : IValidationRule<TEntity>
    {
        private readonly ISpecification<TEntity> _specificationRule;
        public ValidationRule(ISpecification<TEntity> specificationRule, string errorMessage)
        {
            _specificationRule = specificationRule;
            ErrorMessage = errorMessage;
        }
        public string ErrorMessage { get; }

        public bool Valid(TEntity entity)
        {
            return _specificationRule.IsSatisfiedBy(entity);
        }
    }
}
