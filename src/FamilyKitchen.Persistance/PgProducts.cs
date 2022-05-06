using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data;
using System.Data.SqlClient;

namespace FamilyKitchen.Persistance
{
    public class PgProducts : IProducts
    {
        private readonly string connectionString;

        public PgProducts(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<IProduct> Iterate()
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "SELECT Id FROM Products";
            return connection
                .Query(sql)
                .Select(row => new PgProduct(connectionString, row.Id));
        }

        public IProduct Add(string name, MeasureUnit unit)
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "INSERT INTO Products(Name, Unit) OUTPUT INSERTED.Id VALUES(@Name, Unit)";
            var row = connection.QuerySingle(sql,
                new
                {
                    Name = name,
                    Unit = unit
                });
            return new PgProduct(connectionString, row.Id);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "DELETE FROM Products WHERE Id = @Id";
            connection.Execute(sql, new { Id = id });
        }
    }
}
