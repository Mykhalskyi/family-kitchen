using FamilyKitchen.Persistance;
using FamilyKitchen.Shared.Entities;
using FamilyKitchen.WebAPI.Responses;
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
        public ProductsResponse All()
        {
            return new ProductsResponse(
                new PgProducts(connection)
                .Iterate()
                .Select(x => new ProductResponse(x.Id(), x.Name(), x.Unit()))
                .ToList());
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
