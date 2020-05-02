using InternetMarketBackEnd.Core.Domain;
using InternetMarketBackEnd.Core.Domain.Entity;
using InternetMarketBackEnd.Domain.Entity.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace InternetMarketBackEnd.Domain.Entity
{
    public class Category: BaseEntity<long>, ISelfValidation
    {
        public String Name { get;set; }
        public long? ParentId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ValidationResult ValidationResult { get; private set; }
        [NotMapped]
        [JsonIgnore]
        public bool IsValid
        {
            get
            {
                var valid = new OrderIsValidValidation();
                ValidationResult = valid.Valid(new Order { });
                return ValidationResult.IsValid;
            }
        }
    }
}
