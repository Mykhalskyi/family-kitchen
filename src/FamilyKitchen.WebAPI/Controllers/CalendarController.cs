using FamilyKitchen.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyKitchen.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalendarController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<IDay> Between(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void AddMeal(DateTime date, int dishId, int portions)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void RemoveMeal(DateTime date, int dishId)
        {
            throw new NotImplementedException();
        }
    }
}
