using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Domain.Entities
{
    public class Brand : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}