using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data.SqlClient;

namespace FamilyKitchen.Persistance
{
    public class PgDish : IDish
    {
        private readonly string connectionString;

        private readonly int id;

        public PgDish(string connectionString, int id)
        {
            this.id = id;
            this.connectionString = connectionString;
        }

        public int Id() => id;

        public string Name()
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "SELECT Name FROM Dishes WHERE Id = @Id";
            return connection
                .QuerySingle(sql, new { Id = id })
                .Name;
        }

        public IRecipe Recipe()
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "SELECT RecipeId FROM Dishes WHERE Id = @Id";
            var row = connection.QuerySingle(sql, new { Id = id });
            return new PgRecipe(connectionString, row.RecipeId);
        }
    }
}
