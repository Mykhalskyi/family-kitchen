using System.Text.Json.Serialization;

namespace FamilyKitchen.WebAPI.Requests
{
    /// <summary>
    /// DishRequest
    /// </summary>
    [JsonSerializable(typeof(DishRequest))]
    public class DishRequest
    {
        /// <summary>
        /// Name
        /// </summary>
        [JsonInclude]
        public string name;

        /// <summary>
        /// Portions amount
        /// </summary>
        [JsonInclude]
        public readonly int portions;

        /// <summary>
        /// Ingredients 
        /// </summary>
        [JsonInclude]
        public readonly IList<IngredientRequest> ingredients;

        /// <summary>
        /// Notes
        /// </summary>
        [JsonInclude]
        public readonly string notes;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="portions"></param>
        /// <param name="ingredients"></param>
        /// <param name="notes"></param>
        [JsonConstructor]
        public DishRequest(string name, int portions, IList<IngredientRequest> ingredients, string notes)
        {
            this.name = name;
            this.portions = portions;
            this.ingredients = ingredients;
            this.notes = notes;
        }
    }

    /// <summary>
    /// IngredientRequest
    /// </summary>
    [JsonSerializable(typeof(IngredientRequest))]
    public class IngredientRequest
    {
        /// <summary>
        /// ProductId
        /// </summary>
        [JsonInclude]
        public readonly int productId;

        /// <summary>
        /// Amount
        /// </summary>
        [JsonInclude]
        public readonly int amount;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="amount"></param>
        [JsonConstructor]
        public IngredientRequest(int productId, int amount)
        {
            this.productId = productId;
            this.amount = amount;
        }
    }
}
