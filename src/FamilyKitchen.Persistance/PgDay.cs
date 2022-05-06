using Dapper;
using FamilyKitchen.Shared.Entities;
using System.Data;

namespace FamilyKitchen.Persistance
{
    public class PgDay : IDay
    {
        private readonly IDbConnection connection;

        private readonly int id;

        public PgDay(IDbConnection connection, int id)
        {
            this.connection = connection;
            this.id = id;
        }

        public DateTime Date()
        {
            var sql = "SELECT Date FROM Days WHERE Id = @Id";
            return connection
                .QuerySingle(sql, new { Id = id })
                .Date;
        }

        public IEnumerable<ICooking> Menu()
        {
            var sql = "SELECT Id FROM Cookings WHERE DayId = @DayId";
            return connection
                .Query(sql, new { DayId = id })
                .Select(row => new PgCooking(connection, row.Id));
        }

        public ICooking AddCooking(int dishId, int portions)
        {
            var sql = 
                "INSERT INTO Cookings(Date, DishId, Portions) " +
                "OUTPUT INSERTED.Id VALUES(@Date, @DishId, @Portions)";
            var row = connection.QuerySingle(sql,
                new
                {
                    Date = Date(),
                    DishId = dishId,
                    Portions = portions
                });
            return new PgCooking(connection, row.Id);
        }

        public void RemoveCooking(int dishId)
        {
            var sql = "DELETE FROM Cookings WHERE DayId = @DayId";
            connection.Execute(sql, new { DayId = id });
        }
    }
}