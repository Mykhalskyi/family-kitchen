namespace FamilyKitchen.Shared.Entities
{
    public interface IProducts
    {
        public IEnumerable<IProduct> Iterate();

        public IProduct Add(string name, MeasureUnit unit);

        public void Delete(int id);

    }
}
