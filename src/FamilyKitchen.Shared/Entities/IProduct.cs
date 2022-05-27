namespace FamilyKitchen.Shared.Entities
{
    /// <summary>
    /// Product that can be used in recipe.
    /// </summary>
    public interface IProduct : IJson
    {
        /// <summary>
        /// Id of Product.
        /// </summary>
        /// <returns>Id of Product.</returns>
        public int Id();

        /// <summary>
        /// Id of User who owns this Product.
        /// </summary>
        /// <returns></returns>
        public int UserId();

        /// <summary>
        /// Name of Product.
        /// </summary>
        /// <returns>Name of Product.</returns>
        public string Name();

        /// <summary>
        /// Measure unit
        /// </summary>
        /// <returns></returns>
        public MeasureUnit Unit();
    }

    public enum MeasureUnit
    {
        Gramm,
        Liter,
        Pack
    }
}
