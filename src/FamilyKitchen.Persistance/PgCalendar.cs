using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data;
using System.Data.SqlClient;

namespace FamilyKitchen.Persistance
{
    public class PgCalendar : ICalendar
    {
        private readonly string connectionString;

        public PgCalendar(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<IDay> Between(DateTime start, DateTime end)
        {
            using var connection = new SqlConnection(connectionString);
            var sql = "SELECT Id FROM Days WHERE Date >= @Start AND Date <= @End";
            return connection
                .Query(sql, new { Start = start, End = end })
                .Select(row => new PgDay(connectionString, row.Id));
        }
    }
}
