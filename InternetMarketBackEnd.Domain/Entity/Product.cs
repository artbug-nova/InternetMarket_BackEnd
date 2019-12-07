using InternetMarketBackEnd.Core.Domain;
using InternetMarketBackEnd.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
        public bool IsValid => throw new NotImplementedException();
    }
}
