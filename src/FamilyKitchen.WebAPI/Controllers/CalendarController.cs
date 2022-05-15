using FamilyKitchen.Persistance;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json.Nodes;

namespace FamilyKitchen.WebAPI.Controllers
{
    /// <summary>
    /// Operation with Calendar.
    /// </summary>
    [ApiController]
    [Route("calendar")]
    public class CalendarController : ControllerBase
    {
        private readonly IDbConnection connection;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="connection">Database connection.</param>
        public CalendarController(IDbConnection connection) => 
            this.connection = connection;

        /// <summary>
        /// Period of time.
        /// </summary>
        /// <param name="start">Date start.</param>
        /// <param name="end">Date end.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("between")]
        public JsonArray Between(
            [FromQuery] DateTime start, 
            [FromQuery] DateTime end) =>
            new PgPeriod(connection, start, end).Json();

        /// <summary>
        /// Shedule a Cooking.
        /// </summary>
        /// <param name="date">Date.</param>
        /// <param name="dishId">DishId.</param>
        /// <param name="portions">Portions.</param>
        [HttpPost]
        [Route("schedule")]
        public void Schedule(
            [FromQuery] DateTime date, 
            [FromQuery] int dishId, 
            [FromQuery] int portions) => 
            new PgDay(connection, date)
                .Schedule(dishId, portions);

        /// <summary>
        /// Remove a Cooking from schedule.
        /// </summary>
        /// <param name="date">Date.</param>
        /// <param name="dishId">DishId.</param>
        [HttpDelete]
        [Route("unschedule")]
        public void Unschedule(DateTime date, int dishId) => 
            new PgDay(connection, date)
                .Unschedule(dishId);
    }
}
