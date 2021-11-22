using OrderCollectorAPI.Models;

namespace OrderCollectorAPI.Services
{
    public interface IOrderService
    {
        public Task<int> ImportNewOrders();

        public Task<List<Order>> GetUncollectedOrdersAsync();
        public Task<Order> GetOrderByIdAsync(int id);
    }
}
