namespace FamilyKitchen.Persistance.Models
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Measure Measure { get; private set; }
        public ProductType Type { get; private set; }
    }
}
