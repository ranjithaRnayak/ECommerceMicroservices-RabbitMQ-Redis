using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Text.Json;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly IDatabase _redis;
        private static List<string> _products = new() { "Shoes", "Shirt", "Bag" };

        public ProductController()
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            _redis = redis.GetDatabase();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // var cached = await _redis.StringGetAsync("products");
            // if (!cached.IsNullOrEmpty)
            //     return Ok(JsonSerializer.Deserialize<List<string>>(cached));

            // await _redis.StringSetAsync("products", JsonSerializer.Serialize(_products), TimeSpan.FromMinutes(10));
            // return Ok(_products);

            var cached = await _redis.StringGetAsync("products");

            if (!cached.IsNullOrEmpty)
            {
                var result = JsonSerializer.Deserialize<List<string>>(cached!) ?? new();
                return Ok(result);
            }

            await _redis.StringSetAsync("products", JsonSerializer.Serialize(_products), TimeSpan.FromMinutes(10));
            return Ok(_products);
        }
    }
}
