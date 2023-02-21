using FastFood.Domain.Commons;
using FastFood.Domain.Enums;

namespace FastFood.Domain.Entities;
public class Product:Auditable
{
    public string Name { get; set; }
    public double Price { get; set; }
    public ProductStatus Category { get; set; }
}
