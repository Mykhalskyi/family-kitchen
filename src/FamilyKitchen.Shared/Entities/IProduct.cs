namespace FamilyKitchen.Shared.Entities
{
    public interface IProduct
    {
        public int Id();
        public string Name();
        public MeasureUnit Unit();
    }

    public enum MeasureUnit
    {
        Gramm,
        Liter,
        Pack
    }
}
