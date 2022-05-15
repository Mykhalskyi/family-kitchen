namespace FamilyKitchen.Shared.Entities
{
    /// <summary>
    /// Represents Dishes table in database.
    /// </summary>
    public interface IDishes : IJsonArray
    {
        /// <summary>
        /// All dishes.
        /// </summary>
        /// <returns>All dishes.</returns>
        public IEnumerable<IDish> Iterate();

        /// <summary>
        /// Creates new Dish.
        /// </summary>
        /// <param name="name">Name of Dish.</param>
        /// <param name="portions">Portion amount.</param>
        /// <param name="ingredients">Collection of Ingredient.</param>
        /// <param name="notes">Notes.</param>
        /// <returns>Created Dish.</returns>
        public IDish Add(string name, int portions, IEnumerable<(int ProductId, int Amount)> ingredients, string notes);

        /// <summary>
        /// Deletes an existing Dish.
        /// </summary>
        /// <param name="id">Id of existing Dish.</param>
        public void Remove(int id);
    }
}
