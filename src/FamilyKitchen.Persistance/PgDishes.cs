using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data;

namespace FamilyKitchen.Persistance
{
    public class PgDishes : IDishes
    {
        private readonly IDbConnection connection;

        public PgDishes(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<IDish> Iterate()
        {

            var sql = "SELECT Id FROM Dishes";
            return connection
                .Query(sql)
                .Select(row => new PgDish(connection, row.Id));
        }

        public IDish Add(string name, int portions, IEnumerable<(int ProductId, int Amount)> ingredients, string notes)
        {

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

            return new PgDish(connection, insertedDish.Id);
        }

        public void Remove(int id)
        {

            var sql = "DELETE FROM Dishes WHERE Id = @Id";
            connection.Execute(sql, new { Id = id });
        }
    }
}
