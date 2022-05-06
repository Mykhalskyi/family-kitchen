using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data;

namespace FamilyKitchen.Persistance
{
    public class PgCooking : ICooking
    {
        private readonly IDbConnection connection;

        private readonly int id;

        public PgCooking(IDbConnection connection, int id)
        {
            this.connection = connection;
            this.id = id;
        }

        public IDish Dish()
        {

            var sql = "SELECT DishId FROM Cookings WHERE Id = @Id";
            var row = connection.QuerySingle(sql, new { Id = id });
            return new PgDish(connection, row.DishId);
        }

        public int Portions()
        {

            var sql = "SELECT Portions FROM Cookings WHERE Id = @Id";
            return connection
                .QuerySingle(sql, new { Id = id })
                .Portions;
        }
    }
}
