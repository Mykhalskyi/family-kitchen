namespace FamilyKitchen.Shared.Entities
{
    /// <summary>
    /// Represents Products table in database.
    /// </summary>
    public interface IProducts : IJsonArray
    {
        /// <summary>
        /// All Products.
        /// </summary>
        /// <returns>All Products.</returns>
        public IEnumerable<IProduct> Iterate();

        /// <summary>
        /// Creates new Product.
        /// </summary>
        /// <param name="name">Name of Product.</param>
        /// <param name="unit">Measure unit of Product.</param>
        /// <returns>Created Product.</returns>
        public IProduct Add(string name, MeasureUnit unit);

        /// <summary>
        /// Deletes an existing Product.
        /// </summary>
        /// <param name="id">Id of Product.</param>
        public void Remove(int id);
    }
}
