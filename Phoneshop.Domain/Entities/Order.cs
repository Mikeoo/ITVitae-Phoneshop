using Phoneshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Phoneshop.Domain.Entities
{
    public class Order : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        public double VatPercentage { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public ICollection<ProductPerOrder> ProductsPerOrder { get; set; }

        public bool Deleted { get; set; } = false;
        public int Reason { get; set; }

    }
}
