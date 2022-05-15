namespace FamilyKitchen.Shared.Entities
{
    /// <summary>
    /// Dish
    /// </summary>
    public interface IDish : IJson
    {
        /// <summary>
        /// Id of Dish.
        /// </summary>
        /// <returns></returns>
        public int Id();

        /// <summary>
        /// Name of Dish.
        /// </summary>
        /// <returns>Name of Dish.</returns>
        public string Name();

        /// <summary>
        /// Recipe of Dish.
        /// </summary>
        /// <returns>Recipe of Dish.</returns>
        public IRecipe Recipe();
    }
}