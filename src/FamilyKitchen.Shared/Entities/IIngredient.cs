namespace FamilyKitchen.Shared.Entities
{
    /// <summary>
    /// Ingredient, a product in the recipe.
    /// </summary>
    public interface IIngredient : IJson
    {
        /// <summary>
        /// Product.
        /// </summary>
        /// <returns>Product.</returns>
        public IProduct Product();

        /// <summary>
        /// Amount.
        /// </summary>
        /// <returns>Amount.</returns>
        public decimal Amount();
    }
}