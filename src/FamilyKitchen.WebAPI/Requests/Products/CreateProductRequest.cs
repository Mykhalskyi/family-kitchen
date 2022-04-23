using FamilyKitchen.Persistance.Models;

namespace FamilyKitchen.WebAPI.Requests.Products
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public Measure Measure { get; set; }
        public ProductType Type { get; set; }
    }
}
