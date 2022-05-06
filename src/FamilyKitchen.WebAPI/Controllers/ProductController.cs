using FamilyKitchen.Persistance;
using FamilyKitchen.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyKitchen.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly string connectionString;

        public ProductController(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<IProduct> All()
        {
            return new PgProducts(connectionString).Iterate();
        }

        public void Add(string name, MeasureUnit measureUnit)
        {
            new PgProducts(connectionString).Add(name, measureUnit);
        }

        public void Remove(int id)
        {
            new PgProducts(connectionString).Remove(id);
        }
    }
}
