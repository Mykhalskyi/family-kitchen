using FamilyKitchen.Persistance;
using FamilyKitchen.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FamilyKitchen.WebAPI.Controllers
{
    [ApiController]
    [Route("dish")]
    public class DishController : ControllerBase
    {
        private readonly IDbConnection connection;

        public DishController(IDbConnection connection)
        {
            this.connection = connection;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<IDish> All()
        {
            return new PgDishes(connection).Iterate();
        }

        [HttpPost]
        [Route("add")]
        public void Add(
            string name, 
            int portions, 
            IEnumerable<(int ProductId, int Amount)> ingredients, 
            string notes)
        {
            new PgDishes(connection).Add(name, portions, ingredients, notes);
        }

        [HttpDelete]
        [Route("delete")]
        public void Remove(int id)
        {
            new PgDishes(connection).Remove(id);
        }
    }
}
