using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data.SqlClient;

namespace FamilyKitchen.Persistance
{
    public class PgDay : IDay
    {
        private readonly string connectionString;

        private readonly int id;

        public PgDay(string connectionString, int id)
        {
            this.connectionString = connectionString;
            this.id = id;
        }

        public DateTime Date()
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "SELECT Date FROM Days WHERE Id = @Id";
            return connection
                .QuerySingle(sql, new { Id = id })
                .Date;
        }

        public IEnumerable<ICooking> Menu()
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "SELECT Id FROM Cookings WHERE DayId = @DayId";
            return connection
                .Query(sql, new { DayId = id })
                .Select(row => new PgCooking(connectionString, row.Id));

        }

        public ICooking AddCooking(int dishId, int portions)
        {
            using var connection = new SqlConnection(connectionString);
            var sql = 
                "INSERT INTO Cookings(Date, DishId, Portions) " +
                "OUTPUT INSERTED.Id VALUES(@Date, @DishId, @Portions)";
            var row = connection.QuerySingle(sql,
                new
                {
                    Date = Date(),
                    DishId = dishId,
                    Portions = portions
                });
            return new PgCooking(connectionString, row.Id);
        }

        public void RemoveCooking(int dishId)
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "DELETE FROM Cookings WHERE DayId = @DayId";
            connection.Execute(sql, new { DayId = id });
        }
    }
}