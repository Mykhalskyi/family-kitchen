using FamilyKitchen.Persistance;
using FamilyKitchen.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyKitchen.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalendarController : ControllerBase
    {
        private readonly string connectionString;

        public CalendarController(string connectionString)
        {
            this.connectionString = connectionString;
        }

        [HttpGet]
        public IEnumerable<IDay> Between(DateTime start, DateTime end)
        {
            return new PgCalendar(connectionString).Between(start, end);
        }

        [HttpPost]
        public void AddCooking(DateTime date, int dishId, int portions)
        {
            new PgCalendar(connectionString)
                .Day(date)
                .AddCooking(dishId, portions);
        }

        [HttpPost]
        public void RemoveCooking(DateTime date, int dishId)
        {
            new PgCalendar(connectionString)
                .Day(date)
                .RemoveCooking(dishId);
        }
    }
}
