using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data.SqlClient;

namespace FamilyKitchen.Persistance
{
    public class PgProduct : IProduct
    {
        private readonly string connectionString;

        private readonly int id;

        public PgProduct(string connectionString, int id)
        {
            this.connectionString = connectionString;
            this.id = id;
        }

        public int Id() => id;

        public string Name()
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "SELECT Name FROM Products WHERE Id = @Id";
            return connection
                .QuerySingle(sql, new { Id = id })
                .Name;
        }

        public MeasureUnit Unit()
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "SELECT Unit FROM Products WHERE Id = @Id";
            return connection
                .QuerySingle(sql, new { Id = id })
                .Unit;
        }
    }
}
