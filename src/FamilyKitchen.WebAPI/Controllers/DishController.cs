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

        public void Add(string name, IEnumerable<Tuple<int, int>> ingredients, string notes)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
