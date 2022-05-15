using FamilyKitchen.Persistance;
using FamilyKitchen.WebAPI.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json.Nodes;

namespace FamilyKitchen.WebAPI.Controllers
{
    /// <summary>
    /// CRUD operations with Product.
    /// </summary>
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly IDbConnection connection;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="connection">Database connection.</param>
        public ProductController(IDbConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// All Products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public JsonArray All() => new PgProducts(connection).Json();

        /// <summary>
        /// Creates new Product.
        /// </summary>
        /// <param name="product"></param>
        [HttpPost]
        [Route("add")]
        public void Add(ProductRequest product) => 
            new PgProducts(connection).Add(product.name, product.unit);

        /// <summary>
        /// Remove an existing Product.
        /// </summary>
        /// <param name="id">Id.</param>
        [HttpDelete]
        [Route("delete")]
        public void Remove([FromQuery] int id) => 
            new PgProducts(connection).Remove(id);
    }
}
