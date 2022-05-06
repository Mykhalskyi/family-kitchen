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

        public IDish Add(string name, int recipeId)
        {
            using var connection = new SqlConnection(connectionString);
            var sql = 
                "INSERT INTO Dishes(Name, RecipeId) " +
                "OUTPUT INSERTED.Id VALUES(@Name, @RecipeId)";
            var row = connection.QuerySingle(sql,
                new
                {
                    Name = name,
                    RecipeId = recipeId
                });
            return new PgDish(connectionString, row.Id);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "DELETE FROM Dishes WHERE Id = @Id";
            connection.Execute(sql, new { Id = id });
        }
    }
}
