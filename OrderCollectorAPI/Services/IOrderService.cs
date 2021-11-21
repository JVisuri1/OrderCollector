namespace OrderCollectorAPI.Services
{
    public interface IOrderService
    {
        public Task<int> ImportNewOrders();
    }
}
