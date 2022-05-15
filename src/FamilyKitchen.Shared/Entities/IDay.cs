namespace FamilyKitchen.Shared.Entities
{
    /// <summary>
    /// Day.
    /// </summary>
    public interface IDay : IJson
    {
        /// <summary>
        /// Menu. Collection of Cooking.
        /// </summary>
        /// <returns>Collection of Cooking.</returns>
        public IEnumerable<ICooking> СookingPlan();

        /// <summary>
        /// Creates new cooking.
        /// </summary>
        /// <param name="dishId">Id of Dish.</param>
        /// <param name="portions">Amount of portions.</param>
        /// <returns>Created Cooking.</returns>
        public ICooking Schedule(int dishId, int portions);

        /// <summary>
        /// Deletes an exixting Cooking.
        /// </summary>
        /// <param name="dishId">Id of Dish.</param>
        public void Unschedule(int dishId);
    }
}