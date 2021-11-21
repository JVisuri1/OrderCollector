using OrderCollectorAPI.Models;

namespace OrderCollectorAPI
{
    public class Order
    {
        public int id { get; set; }

        public int customerId { get; set; }
        public string customerName { get; set; }

        public string invoiceAddress { get; set; }
        public string deliveryAddress { get; set; }
        public DateTime deliveryDate { get; set; }
        public string seller { get; set; }
        public decimal orderPrice { get; set; }

        public List<OrderRow> orderrows { get; set; }
    }
}