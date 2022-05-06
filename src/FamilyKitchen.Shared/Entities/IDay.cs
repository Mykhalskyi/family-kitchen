namespace FamilyKitchen.Shared.Entities
{
    public interface IDay
    {
        public DateTime Date();
        public IEnumerable<ICooking> Menu();
        public ICooking AddCooking(int dishId, int portions);
        public void RemoveCooking(int dishId);
    }
}