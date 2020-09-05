using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crafts.Models;
using Crafts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crafts.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(ProductService productService)
        {
            this.product = productService;
        }

        public ProductService product { get; set; }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return product.GetProducts();
        }

        [HttpGet]
        [Route("Rate")]
        public IActionResult Get([FromQuery] string productId, [FromQuery]int rating)
        {
            product.AddRatings(productId, rating);
            return Ok();
        }
    }
}
