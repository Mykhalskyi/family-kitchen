namespace FamilyKitchen.Shared.Entities
{
    public interface IDish
    {
        public int Id();
        public string Name();
        public IRecipe Recipe();

        public class Simple : IDish
        {
            private readonly int id;
            private readonly string name;
            private readonly IRecipe recipe;

            public Simple(int id, string name, IRecipe recipe)
            {
                this.id = id;
                this.name = name;
                this.recipe = recipe;
            }

            public int Id() => id;
            public string Name() => name;
            public IRecipe Recipe() => recipe;
        }
    }
}