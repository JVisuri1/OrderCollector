using Microsoft.EntityFrameworkCore;
using OrderCollectorAPI.Models;

namespace OrderCollectorAPI.Data
{
    public class BaseContext: DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }
        public DbSet<Order> orders { get; set; }

        public DbSet<OrderRow> order_rows { get; set; }
    }
}
