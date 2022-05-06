namespace FamilyKitchen.Shared.Entities
{
    public interface IDishes
    {
        public IEnumerable<IDish> Iterate();
        public IDish Add(string name, int recipeId);
        public void Delete(int id);
    }
}
