using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data;
using System.Text.Json.Nodes;

namespace FamilyKitchen.Persistance
{
    public class PgDish : IDish
    {
        private readonly IDbConnection connection;

        private readonly int id;

        public PgDish(IDbConnection connection, int id)
        {
            this.id = id;
            this.connection = connection;
        }

        public int Id() => id;

        public int UserId()
        {
            var sql = "SELECT UserId FROM Dishes WHERE Id = @Id";
            return connection.QuerySingle(sql, new { Id = id }).UserId;
        }

        public string Name()
        {
            var sql = "SELECT Name FROM Dishes WHERE Id = @Id";
            return connection
                .QuerySingle(sql, new { Id = id })
                .Name;
        }

        public IRecipe Recipe()
        {
            var sql = "SELECT Id FROM Recipes WHERE DishId = @DishId";
            var row = connection.QuerySingle(sql, new { DishId = id });
            return new PgRecipe(connection, row.Id);
        }

        public JsonObject Json() =>
            new(new Dictionary<string, JsonNode?>
            {
                { "id", id },
                { "name", Name() },
                { "recipe", Recipe().Json() }
            });
    }
}
