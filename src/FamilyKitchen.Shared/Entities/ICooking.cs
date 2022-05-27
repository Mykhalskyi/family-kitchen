namespace FamilyKitchen.Shared.Entities
{
    /// <summary>
    /// Planned activity of cooking a Dish.
    /// </summary>
    public interface ICooking : IJson
    {
        /// <summary>
        /// Id of user who owns this Cooking.
        /// </summary>
        /// <returns></returns>
        public int UserId();

        /// <summary>
        /// Dish that is planned to cook.
        /// </summary>
        /// <returns>Dish.</returns>
        public IDish Dish();

        /// <summary>
        /// Amount of portions.
        /// </summary>
        /// <returns>Amount of portions.</returns>
        public int Portions();
    }
}