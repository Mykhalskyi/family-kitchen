using FamilyKitchen.Persistance;
using FamilyKitchen.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FamilyKitchen.WebAPI.Controllers
{
    [ApiController]
    [Route("calendar")]
    public class CalendarController : ControllerBase
    {
        private readonly IDbConnection connection;

        public CalendarController(IDbConnection connection)
        {
            this.connection = connection;
        }

        [HttpGet]
        [Route("between")]
        public IEnumerable<IDay> Between(DateTime start, DateTime end)
        {
            return new PgCalendar(connection).Between(start, end);
        }

        [HttpPost]
        [Route("add-cooking")]
        public void AddCooking(DateTime date, int dishId, int portions)
        {
            new PgCalendar(connection)
                .Day(date)
                .AddCooking(dishId, portions);
        }

        [HttpDelete]
        [Route("delete-cooking")]
        public void RemoveCooking(DateTime date, int dishId)
        {
            new PgCalendar(connection)
                .Day(date)
                .RemoveCooking(dishId);
        }
    }
}
