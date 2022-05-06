using FamilyKitchen.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyKitchen.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DishController : ControllerBase
    {
        public IEnumerable<IDish> All()
        {
            throw new NotImplementedException();
        }

        public void Add(string name, int portions, IEnumerable<Tuple<int, int>> ingredients, string notes)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
