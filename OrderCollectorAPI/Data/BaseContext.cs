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

        public DbSet<User> users { get; set; }

        public DbSet<UserLogin> user_logins { get; set; }
    }
}
