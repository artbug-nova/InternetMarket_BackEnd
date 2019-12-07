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
    [Table("Order")]
    public class Order : BaseEntity<long>, ISelfValidation
    {
        //public Order() { }
        
        public String Name { get; set; }
        public decimal Price { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        [NotMapped]
        [JsonIgnore]
        public ValidationResult ValidationResult { get; private set; }
        [NotMapped]
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
