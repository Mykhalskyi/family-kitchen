namespace FamilyKitchen.Shared.Entities
{
    public interface IIngredient
    {
        public IProduct Product();
        public decimal Amount();
    }
}