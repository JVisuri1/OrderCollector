using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OrderCollectorAPI.Data;
using OrderCollectorAPI.Models;
using System.Text.Json;

namespace OrderCollectorAPI.Services
{
    public class OrderService: IOrderService
    {
        private readonly BaseContext _context;

        public OrderService(BaseContext context)
        {
            _context = context;
        }

        public async Task<int> ImportNewOrders()
        {
            using (var client = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Get,
                    "https://www.cc.puv.fi/~asa/json/project.json");

                var response = await client.SendAsync(httpRequestMessage);
                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();

                var format = "d-MM-yyyy";
                var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };

                var parsed = JsonConvert.DeserializeObject<List<Order>>(body, dateTimeConverter);

                var newOrders = parsed.Where(o => !_context.orders.Select(x => x.OrderId).Contains(o.OrderId)).ToList();

                _context.orders.AddRange(newOrders);
                await _context.SaveChangesAsync();


                return newOrders.Count;
            }
        }

        public async Task<List<Order>> GetUncollectedOrdersPagedAsync(int page, int pageSize)
        {
            return await _context.orders.Where(o => o.Collected == false).Take(pageSize).Skip(page * pageSize -1).ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int Id)
        {
            return await _context.orders.Where(o => o.Id == Id).Include(o => o.OrderRows).FirstOrDefaultAsync();
        }
    }
}
