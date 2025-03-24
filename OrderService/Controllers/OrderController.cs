using Microsoft.AspNetCore.Mvc;
using OrderService.Services;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly RabbitMQPublisher _publisher = new();

        [HttpPost]
        public IActionResult PlaceOrder([FromBody] string product)
        {
            Console.WriteLine($"[OrderService] 🛒 Order received: {product}");
            _publisher.Publish(product);

            return Ok($"Order placed for {product}!");
        }
    }
}
