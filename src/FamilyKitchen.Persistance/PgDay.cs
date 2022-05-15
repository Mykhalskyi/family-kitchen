using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data;
using System.Text.Json.Nodes;

namespace FamilyKitchen.Persistance
{
    public class PgDay : IDay
    {
        private readonly IDbConnection connection;

        private readonly DateTime date;

        public PgDay(IDbConnection connection, DateTime date)
        {
            this.connection = connection;
            this.date = date;
        }

        public IEnumerable<ICooking> СookingPlan() =>
            connection
                .Query(
                    "SELECT Id FROM Cookings WHERE Date = @Date",
                    new { Date = date })
                .Select(row => new PgCooking(connection, row.Id));

        public ICooking Schedule(int dishId, int portions)
        {
            var row = connection.QuerySingle(
                "INSERT INTO Cookings(Date, DishId, Portions) " +
                "OUTPUT INSERTED.Id VALUES(@Date, @DishId, @Portions)",
                new
                {
                    Date = date,
                    DishId = dishId,
                    Portions = portions
                });
            return new PgCooking(connection, row.Id);
        }

        public void Unschedule(int dishId) =>
            connection.Execute(
                "DELETE FROM Cookings WHERE Date = @Date AND DishId = @DishId",
                new { Date = date, DishId = dishId });

        public JsonObject Json() =>
            new(new Dictionary<string, JsonNode?>()
            {
                { $"{nameof(date)}", JsonValue.Create(date) },
                { $"cookingPlan", new JsonArray(СookingPlan()
                                                .Select(cooking => cooking.Json())
                                                .ToArray()) },
            });
    }
}