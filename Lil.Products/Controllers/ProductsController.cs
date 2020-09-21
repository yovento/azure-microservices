using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.Products.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsProvider productsProvider;
        public ProductsController(IProductsProvider productsProvider)
        {
            this.productsProvider = productsProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await this.productsProvider.GetAsync(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
            
        }
    }
}