using System.Text.Json.Nodes;

namespace FamilyKitchen.Shared.Entities
{
    public interface IJson
    {
        JsonObject Json();
    }

    public interface IJsonArray
    {
        JsonArray Json();
    }
}
