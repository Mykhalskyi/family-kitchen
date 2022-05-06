using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data;

namespace FamilyKitchen.Persistance
{
    public class PgCalendar : ICalendar
    {
        private readonly IDbConnection connection;

        public PgCalendar(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<IDay> Between(DateTime start, DateTime end)
        {
            var sql = "SELECT Id FROM Days WHERE Date >= @Start AND Date <= @End";
            return connection
                .Query(sql, new { Start = start, End = end })
                .Select(row => new PgDay(connection, row.Id));
        }

        public IDay Day(DateTime date)
        {
            var sql = "SELECT Id FROM Days WHERE Date = @Date";
            var row = connection.QuerySingle(sql, new { Date = date });
            return new PgDay(connection, row.Id);
        }
    }
}
