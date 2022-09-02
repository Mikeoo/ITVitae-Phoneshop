using System.Collections.Generic;
using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Domain.Entities
{
    public class Phone : IEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public string FullName => $"{Brand?.Name} {Type}";
    }
}