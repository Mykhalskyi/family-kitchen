using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data;

namespace FamilyKitchen.Persistance
{
    public class PgRecipe : IRecipe
    {
        private readonly IDbConnection connection;

        private readonly int id;

        public PgRecipe(IDbConnection connection, int id)
        {
            this.connection = connection;
            this.id = id;
        }

        public IEnumerable<IIngredient> Ingredients()
        {

            var sql = "SELECT Id FROM Ingredients WHERE RecipeId = @Id";
            return connection
                .Query(sql, new { Id = id })
                .Select(row => new PgIngredient(connection, row.Id));
        }

        public string Notes()
        {

            var sql = "SELECT Notes FROM Recipes WHERE Id = @Id";
            return connection
                .QuerySingle(sql, new { Id = id })
                .Notes;
        }
        public int Portions()
        {

            var sql = "SELECT Portions FROM Recipes WHERE Id = @Id";
            return connection
                .QuerySingle(sql, new { Id = id })
                .Portions;
        }
    }
}
