namespace FamilyKitchen.Shared.Entities
{
    public interface IUser : IJson
    {
        public IPeriod Between(DateTime start, DateTime end);

        public IProducts Products();

        public IDishes Dishes();
    }
}
