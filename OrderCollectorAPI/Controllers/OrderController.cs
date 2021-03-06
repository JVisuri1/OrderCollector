using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderCollectorAPI.Data;
using OrderCollectorAPI.Models;
using OrderCollectorAPI.Services;

namespace OrderCollectorAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        public readonly IOrderService _orderService;

        public readonly BaseContext _baseContext;

        public OrderController(IOrderService orderService, BaseContext context)
        {
            _orderService = orderService;
            _baseContext = context;
        }

        [HttpGet("GetOrders")]
        public IEnumerable<Order> Get()
        {
            return _baseContext.orders;
        }

        [HttpGet("RefreshOrders")]
        public async Task<ActionResult> RefreshOrders()
        {
            var resultCount = await _orderService.ImportNewOrders();
            return Ok(resultCount);
        }

        [HttpGet("GetUncollectedOrders")]
        public async Task<List<Order>> GetUncollectedOrders(int page, int pageSize)
        {
            return await _orderService.GetUncollectedOrdersPagedAsync(page, pageSize);
        }

        [HttpGet("GetOrderById/{id}")]
        public async Task<Order> GetOrder(int id)
        {
            return await _orderService.GetOrderByIdAsync(id);
        }
    }
}