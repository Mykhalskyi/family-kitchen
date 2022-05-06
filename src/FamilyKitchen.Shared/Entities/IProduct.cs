namespace FamilyKitchen.Shared.Entities
{
    public interface IProduct
    {
        public int Id();
        public string Name();
        public MeasureUnit Unit();

        public class Simple : IProduct
        {
            private readonly int id;
            private readonly string name;
            private readonly MeasureUnit unit;

            public Simple(int id, string name, MeasureUnit unit)
            {
                this.id = id;
                this.name = name;
                this.unit = unit;
            }

            public int Id() => id;
            public string Name() => name;
            public MeasureUnit Unit() => unit;
        }
    }

    public enum MeasureUnit
    {
        Gramm,
        Liter,
        Pack
    }
}
