using FamilyKitchen.Persistance.Models;

namespace FamilyKitchen.WebAPI.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Measure Measure { get; set; }
        public ProductType Type { get; set; }
    }
}
