using FamilyKitchen.Persistance;
using FamilyKitchen.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyKitchen.WebAPI.Controllers
{
    [ApiController]
    [Route("calendar")]
    public class CalendarController : ControllerBase
    {
        private readonly string connectionString;

        public CalendarController()
        {
            this.connectionString = "";
        }

        [HttpGet]
        [Route("between")]
        public IEnumerable<IDay> Between(DateTime start, DateTime end)
        {
            return new PgCalendar(connectionString).Between(start, end);
        }

        [HttpPost]
        [Route("add-cooking")]
        public void AddCooking(DateTime date, int dishId, int portions)
        {
            new PgCalendar(connectionString)
                .Day(date)
                .AddCooking(dishId, portions);
        }

        [HttpDelete]
        [Route("delete-cooking")]
        public void RemoveCooking(DateTime date, int dishId)
        {
            new PgCalendar(connectionString)
                .Day(date)
                .RemoveCooking(dishId);
        }
    }
}
