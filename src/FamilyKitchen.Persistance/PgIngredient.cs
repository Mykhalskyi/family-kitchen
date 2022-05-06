using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data;

namespace FamilyKitchen.Persistance
{
    public class PgIngredient : IIngredient
    {
        private readonly IDbConnection connection;

        private readonly int id;

        public PgIngredient(IDbConnection connection, int id)
        {
            this.connection = connection;
            this.id = id;
        }

        public decimal Amount()
        {

            var sql = "SELECT Amount FROM Ingredients WHERE Id = @Id";
            return connection
                .QuerySingle(sql, new { Id = id })
                .Amount;
        }

        public IProduct Product()
        {

            var sql = "SELECT ProductId FROM Ingredients WHERE Id = @Id";
            var row = connection.QuerySingle(sql, new { Id = id });
            return new PgProduct(connection, row.ProductId);
        }
    }
}
