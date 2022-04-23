namespace FamilyKitchen.Persistance.Models
{
    public class Ingredient
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Measure Measure { get; private set; }
        public IngredientType Type { get; private set; }
    }
}
