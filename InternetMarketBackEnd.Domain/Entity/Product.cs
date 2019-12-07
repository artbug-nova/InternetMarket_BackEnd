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
    [Table("Product")]
    public class Product : BaseEntity<long>, ISelfValidation
    {
        [Column("Name_product")]
        public String Name { get; set; }
        [Column("Description_product")]
        public String Description { get; set; }
        [Column("Price_product")]
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<OrderUserBag> OrderUserBags{ get; set; }
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
