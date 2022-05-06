using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data;
using System.Data.SqlClient;

namespace FamilyKitchen.Persistance
{
    public class PgRecipe : IRecipe
    {
        private readonly string connectionString;

        private readonly int id;

        public PgRecipe(string connectionString, int id)
        {
            this.connectionString = connectionString;
            this.id = id;
        }

        public IEnumerable<IIngredient> Ingredients()
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "SELECT Id FROM Ingredients WHERE RecipeId = @Id";
            return connection
                .Query(sql, new { Id = id })
                .Select(row => new PgIngredient(connectionString, row.Id));
        }

        public string Notes()
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "SELECT Notes FROM Recipes WHERE Id = @Id";
            return connection
                .QuerySingle(sql, new { Id = id })
                .Notes;
        }
        public int Portions()
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "SELECT Portions FROM Recipes WHERE Id = @Id";
            return connection
                .QuerySingle(sql, new { Id = id })
                .Portions;
        }
    }
}
