using FamilyKitchen.Persistance;
using FamilyKitchen.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FamilyKitchen.WebAPI.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly IDbConnection connection;

        public ProductController(IDbConnection connection)
        {
            this.connection = connection;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<IProduct> All()
        {
            return new PgProducts(connection).Iterate();
        }

        [HttpPost]
        [Route("add")]
        public void Add(string name, MeasureUnit measureUnit)
        {
            new PgProducts(connection).Add(name, measureUnit);
        }

        [HttpDelete]
        [Route("delete")]
        public void Remove(int id)
        {
            new PgProducts(connection).Remove(id);
        }
    }
}
