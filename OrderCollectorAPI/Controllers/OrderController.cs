using Microsoft.AspNetCore.Mvc;

namespace OrderCollectorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        public OrderController()
        {

        }

        [HttpGet("GetOrders")]
        public IEnumerable<Order> Get()
        {
            return new List<Order>() { new Order() { id = 1, deliveryDate = DateTime.Now} };
        }

        [HttpGet("RefreshOrders")]
        public ActionResult RefreshOrders()
        {
            return Ok(5);
        }
    }
}