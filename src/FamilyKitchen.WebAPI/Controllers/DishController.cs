using FamilyKitchen.Persistance;
using FamilyKitchen.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyKitchen.WebAPI.Controllers
{
    [ApiController]
    [Route("dish")]
    public class DishController : ControllerBase
    {
        private readonly string connectionString;

        public DishController()
        {
            this.connectionString = "";
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<IDish> All()
        {
            return new PgDishes(connectionString).Iterate();
        }

        [HttpPost]
        [Route("add")]
        public void Add(
            string name, 
            int portions, 
            IEnumerable<(int ProductId, int Amount)> ingredients, 
            string notes)
        {
            new PgDishes(connectionString).Add(name, portions, ingredients, notes);
        }

        [HttpDelete]
        [Route("delete")]
        public void Remove(int id)
        {
            new PgDishes(connectionString).Remove(id);
        }
    }
}
