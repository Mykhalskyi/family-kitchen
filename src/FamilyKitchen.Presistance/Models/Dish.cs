namespace FamilyKitchen.Persistance.Models
{
    public class Dish
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Recipe Recipe { get; private set; }
    }
}
