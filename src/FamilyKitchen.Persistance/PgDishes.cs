using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data;
using System.Data.SqlClient;

namespace FamilyKitchen.Persistance
{
    public class PgDishes : IDishes
    {
        private readonly string connectionString;

        public PgDishes(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<IDish> Iterate()
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "SELECT Id FROM Dishes";
            return connection
                .Query(sql)
                .Select(row => new PgDish(connectionString, row.Id));
        }

        public IDish Add(string name, int portions, IEnumerable<(int ProductId, int Amount)> ingredients, string notes)
        {
            using var connection = new SqlConnection(connectionString);
            var sql = 
                "INSERT INTO Dishes(Name) " +
                "OUTPUT INSERTED.Id VALUES(@Name)";
            var insertedDish = connection.QuerySingle(sql, new { Name = name });

            var sqlInsertRecipe =
                "INSERT INTO Recipes(DishId, Portions, Notes) " +
                "OUTPUT INSERTED.Id VALUES(@DishId, @Portions, @Notes)";
            var insertedRecipe = connection.QuerySingle(sqlInsertRecipe,
                new
                {
                    DishId = insertedDish.Id(),
                    Portions = portions,
                    Notes = notes
                });

            var sqlInsertIngredient = 
                "INSERT INTO Ingredients(ProductId, RecipeId, Amount) " +
                "VALUES(@ProductId, @RecipeId, @Amount)";
            foreach (var (ProductId, Amount) in ingredients)
                connection.Execute(sqlInsertIngredient,
                    new
                    {
                        ProductId,
                        RecipeId = insertedRecipe.Id,
                        Amount,
                    });

            return new PgDish(connectionString, insertedDish.Id);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "DELETE FROM Dishes WHERE Id = @Id";
            connection.Execute(sql, new { Id = id });
        }
    }
}
