namespace FamilyKitchen.Shared.Entities
{
    /// <summary>
    /// Recipe of the Dish.
    /// </summary>
    public interface IRecipe : IJson
    {
        /// <summary>
        /// Portions amount recipe is designed for.
        /// </summary>
        /// <returns>Amount of portions.</returns>
        public int Portions();

        /// <summary>
        /// Collection of ingredients need for recipe.
        /// </summary>
        /// <returns>Collection of Ingredients.</returns>
        public IEnumerable<IIngredient> Ingredients();

        /// <summary>
        /// Notes for recipe.
        /// </summary>
        /// <returns>Notes.</returns>
        public string Notes();
    }
}