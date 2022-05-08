using FamilyKitchen.Shared.Entities;
using System.Text.Json.Serialization;

namespace FamilyKitchen.WebAPI.Responses
{
    [JsonSerializable(typeof(ProductsResponse))]
    public class ProductsResponse
    {
        [JsonInclude]
        public readonly List<ProductResponse> Products;
        
        [JsonConstructor]
        public ProductsResponse(List<ProductResponse> products)
        {
            Products = products;
        }
    }

    [JsonSerializable(typeof(ProductResponse))]
    public class ProductResponse
    {
        [JsonInclude]
        public readonly int Id;
        [JsonInclude]
        public readonly string Name;
        [JsonInclude]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public readonly MeasureUnit Unit;

        [JsonConstructor]
        public ProductResponse(int id, string name, MeasureUnit unit)
        {
            Id = id;
            Name = name;
            Unit = unit;
        }
    }
}
