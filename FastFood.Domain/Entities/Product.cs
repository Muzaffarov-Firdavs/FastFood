using FastFood.Domain.Commons;
using FastFood.Domain.Enums;

namespace FastFood.Domain.Entities
{
    public class Product:Auditable
    {
        public long OwnerId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductStatus Category { get; set; }
    }

}
