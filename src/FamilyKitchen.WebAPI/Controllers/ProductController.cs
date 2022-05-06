using FamilyKitchen.Persistance;
using FamilyKitchen.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

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
            var newProduct = new PgProducts(connectionString).Add(name, measureUnit);
        }

        public void Remove(int id)
        {
            new PgProducts(connectionString).Delete(id);
        }
    }
}
