namespace FamilyKitchen.Shared.Entities
{
    public interface IDishes
    {
        public IEnumerable<IDish> Iterate();
        public IDish Add(string name, int portions, IEnumerable<(int ProductId, int Amount)> ingredients, string notes);
        public void Remove(int id);
    }
}
