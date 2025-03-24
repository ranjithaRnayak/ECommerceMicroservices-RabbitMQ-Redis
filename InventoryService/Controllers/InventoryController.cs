using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("inventory")]
    public class InventoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Inventory service is running!");
        }
    }
}
