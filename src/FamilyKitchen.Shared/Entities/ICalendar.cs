namespace FamilyKitchen.Shared.Entities
{
    public interface ICalendar
    {
        public IEnumerable<IDay> Between(DateTime start, DateTime end);

        public IDay Day(DateTime date);
    }
}
