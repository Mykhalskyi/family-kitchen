using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data.SqlClient;

namespace FamilyKitchen.Persistance
{
    public class PgIngredient : IIngredient
    {
        private readonly string connectionString;

        private readonly int id;

        public PgIngredient(string connectionString, int id)
        {
            this.connectionString = connectionString;
            this.id = id;
        }

        public decimal Amount()
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "SELECT Amount FROM Ingredients WHERE Id = @Id";
            return connection
                .QuerySingle(sql, new { Id = id })
                .Amount;
        }

        public IProduct Product()
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "SELECT ProductId FROM Ingredients WHERE Id = @Id";
            var row = connection.QuerySingle(sql, new { Id = id });
            return new PgProduct(connectionString, row.ProductId);
        }
    }
}
