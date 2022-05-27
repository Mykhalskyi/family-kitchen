using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data;
using System.Text.Json.Nodes;

namespace FamilyKitchen.Persistance
{
    public class PgProduct : IProduct
    {
        private readonly IDbConnection connection;

        private readonly int id;

        public PgProduct(IDbConnection connection, int id)
        {
            this.connection = connection;
            this.id = id;
        }

        public int Id() => id;

        public int UserId()
        {
            var sql = "SELECT UserId FROM Products WHERE Id = @Id";
            return connection.QuerySingle(sql, new { Id = id }).UserId;
        }

        public string Name()
        {
            var sql = "SELECT Name FROM Products WHERE Id = @Id";
            return connection
                .QuerySingle(sql, new { Id = id })
                .Name;
        }

        public MeasureUnit Unit()
        {
            var sql = "SELECT Unit FROM Products WHERE Id = @Id";
            return (MeasureUnit)connection
                .QuerySingle(sql, new { Id = id })
                .Unit;
        }

        public JsonObject Json() =>
            new(new Dictionary<string, JsonNode?>
            {
                { "id", id },
                { "name", Name() },
                { "unit", Unit().ToString() }
            });
    }
}
