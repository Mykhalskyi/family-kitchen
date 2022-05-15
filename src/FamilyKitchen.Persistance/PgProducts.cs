using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data;
using System.Text.Json.Nodes;

namespace FamilyKitchen.Persistance
{
    public class PgProducts : IProducts
    {
        private readonly IDbConnection connection;

        public PgProducts(IDbConnection connection)
        {
            this.connection = connection;
        }
         
        public IEnumerable<IProduct> Iterate()
        {
            var sql = "SELECT Id FROM Products";
            return connection
                .Query(sql)
                .Select(row => new PgProduct(connection, row.Id));
        }

        public IProduct Add(string name, MeasureUnit unit)
        {
            var sql = "INSERT INTO Products(Name, Unit) OUTPUT INSERTED.Id VALUES(@Name, @Unit)";
            var row = connection.QuerySingle(sql,
                new
                {
                    Name = name,
                    Unit = unit
                });
            return new PgProduct(connection, row.Id);
        }

        public void Remove(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            connection.Execute(sql, new { Id = id });
        }

        public JsonArray Json() =>
            new(Iterate().Select(product => product.Json()).ToArray());
    }
}
