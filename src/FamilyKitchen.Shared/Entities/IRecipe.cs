namespace FamilyKitchen.Shared.Entities
{
    public interface IRecipe
    {
        public int Portions();
        public IEnumerable<IIngredient> Ingredients();
        public string Notes();
    }
}