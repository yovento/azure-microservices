using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.Customers.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersProvider customersProvider;
        public CustomersController(ICustomersProvider customersProvider)
        {
            this.customersProvider = customersProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await this.customersProvider.GetAsync(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}