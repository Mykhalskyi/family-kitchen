using FamilyKitchen.WebAPI.Requests.Products;
using FamilyKitchen.WebAPI.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FamilyKitchen.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        
        public ProductController()
        {

        }

        public async Task<List<ProductResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductResponse> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Create(CreateProductRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task Edit(EditProductRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
