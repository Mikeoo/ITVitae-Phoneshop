using System.ComponentModel.DataAnnotations.Schema;

namespace Phoneshop.Domain.Entities
{
    public class ProductPerOrder
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public Phone Product { get; set; }

        // Foreign Key Relationship
        [ForeignKey("OrderForeignKey")]
        public int? OrderId { get; set; }
    }
}
