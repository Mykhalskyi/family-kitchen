using FamilyKitchen.Persistance;
using FamilyKitchen.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyKitchen.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DishController : ControllerBase
    {
        private readonly string connectionString;

        public DishController(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<IDish> All()
        {
            return new PgDishes(connectionString).Iterate();
        }

        public void Add(
            string name, 
            int portions, 
            IEnumerable<(int ProductId, int Amount)> ingredients, 
            string notes)
        {
            new PgDishes(connectionString).Add(name, portions, ingredients, notes);
        }

        public void Remove(int id)
        {
            new PgDishes(connectionString).Remove(id);
        }
    }
}
