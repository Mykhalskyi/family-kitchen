namespace FamilyKitchen.Shared.Entities
{
    public interface IDish
    {
        public int Id();
        public string Name();
        public IRecipe Recipe();
    }
}