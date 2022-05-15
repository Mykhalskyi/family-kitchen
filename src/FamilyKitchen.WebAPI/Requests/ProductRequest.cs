using FamilyKitchen.Shared.Entities;
using System.Text.Json.Serialization;

namespace FamilyKitchen.WebAPI.Requests
{
    /// <summary>
    /// ProductRequest.
    /// </summary>
    [JsonSerializable(typeof(ProductRequest))]
    public class ProductRequest
    {
        /// <summary>
        /// Name.
        /// </summary>
        [JsonInclude]
        public readonly string name;
        /// <summary>
        /// Unit.
        /// </summary>
        [JsonInclude]
        public readonly MeasureUnit unit;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="unit">Unit.</param>
        [JsonConstructor]
        public ProductRequest(string name, MeasureUnit unit)
        {
            this.name = name;
            this.unit = unit;
        }
    }
}
