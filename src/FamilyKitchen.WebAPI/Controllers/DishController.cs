using FamilyKitchen.Persistance;
using FamilyKitchen.WebAPI.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json.Nodes;

namespace FamilyKitchen.WebAPI.Controllers
{
    /// <summary>
    /// CRUD Operations with Dish.
    /// </summary>
    [ApiController]
    [Route("dish")]
    public class DishController : ControllerBase
    {
        private readonly IDbConnection connection;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="connection">Database connection.</param>
        public DishController(IDbConnection connection) => 
            this.connection = connection;

        /// <summary>
        /// Returns all Dishes.
        /// </summary>
        /// <returns>Collection of Dishes.</returns>
        [HttpGet]
        [Route("all")]
        public JsonArray All() => new PgDishes(connection).Json();

        /// <summary>
        /// Creates new Dish.
        /// </summary>
        /// <param name="dish"></param>
        [HttpPost]
        [Route("add")]
        public void Add([FromBody] DishRequest dish) => 
            new PgDishes(connection).Add(
                dish.name,
                dish.portions,
                dish.ingredients.Select(x => (x.productId, x.amount)),
                dish.notes);

        /// <summary>
        /// Deletes an existing Dish.
        /// </summary>
        /// <param name="id">Id.</param>
        [HttpDelete]
        [Route("delete")]
        public void Remove(int id) => 
            new PgDishes(connection).Remove(id);
    }
}
