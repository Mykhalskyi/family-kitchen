using FamilyKitchen.Shared.Entities;
using System.Data;
using System.Text.Json.Nodes;

namespace FamilyKitchen.Persistance
{
    public class PgUser : IUser
    {
        private readonly IDbConnection connection;
        private readonly int id;

        public PgUser(IDbConnection connection, int id)
        {
            this.connection = connection;
            this.id = id;
        }

        public IPeriod Between(DateTime start, DateTime end) => new PgPeriod(connection, start, end);

        public IDishes Dishes() => new PgDishes(connection);

        public IProducts Products() => new PgProducts(connection);

        public JsonObject Json() => new(new Dictionary<string, JsonNode?>()
            {
                { "id", JsonValue.Create(id) },
                { "dishes", Dishes().Json() },
                { "products", Products().Json() }
            });
    }
}
