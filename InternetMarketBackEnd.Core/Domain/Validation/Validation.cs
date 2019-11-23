using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Core.Domain.Validation
{
    public class Validation<TEntity>: IValidation<TEntity> where TEntity:class
    {
        private readonly Dictionary<String, IValidationRule<TEntity>> _validationRule;

        public Validation()
        {
            _validationRule = new Dictionary<string, IValidationRule<TEntity>>();
        }

        protected virtual void AddRule(IValidationRule<TEntity> validationRule)
        {
            var ruleName = validationRule.GetType() + Guid.NewGuid().ToString("D");
            _validationRule.Add(ruleName, validationRule);
        }

        protected virtual void RemoveRule(string ruleName)
        {
            _validationRule.Remove(ruleName);
        }

        public ValidationResult Valid(TEntity entity)
        {
            var result = new ValidationResult();

            foreach(var key in _validationRule.Keys)
            {
                var rule = _validationRule[key];
                if (!rule.Valid(entity))
                    result.Add(new ValidationError(rule.ErrorMessage));
            }
            return result;
        }
    }
}
