using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data.SqlClient;

namespace FamilyKitchen.Persistance
{
    public class PgCooking : ICooking
    {
        private readonly string connectionString;

        private readonly int id;

        public PgCooking(string connectionString, int id)
        {
            this.connectionString = connectionString;
            this.id = id;
        }

        public IDish Dish()
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "SELECT DishId FROM Cookings WHERE Id = @Id";
            var row = connection.QuerySingle(sql, new { Id = id });
            return new PgDish(connectionString, row.DishId);
        }

        public int Portions()
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "SELECT Portions FROM Cookings WHERE Id = @Id";
            return connection
                .QuerySingle(sql, new { Id = id })
                .Portions;
        }
    }
}
