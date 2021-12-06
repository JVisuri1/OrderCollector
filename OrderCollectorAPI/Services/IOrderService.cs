using OrderCollectorAPI.Models;

namespace OrderCollectorAPI.Services
{
    public interface IOrderService
    {
        public Task<int> ImportNewOrders();

        public Task<List<Order>> GetUncollectedOrdersPagedAsync(int page, int pageSize);
        public Task<Order> GetOrderByIdAsync(int id);
    }
}
