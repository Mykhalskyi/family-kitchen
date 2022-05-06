using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data;

namespace FamilyKitchen.Persistance
{
    public class PgDish : IDish
    {
        private readonly IDbConnection connection;

        private readonly int id;

        public PgDish(IDbConnection connection, int id)
        {
            this.id = id;
            this.connection = connection;
        }

        public int Id() => id;

        public string Name()
        {

            var sql = "SELECT Name FROM Dishes WHERE Id = @Id";
            return connection
                .QuerySingle(sql, new { Id = id })
                .Name;
        }

        public IRecipe Recipe()
        {

            var sql = "SELECT RecipeId FROM Dishes WHERE Id = @Id";
            var row = connection.QuerySingle(sql, new { Id = id });
            return new PgRecipe(connection, row.RecipeId);
        }
    }
}
