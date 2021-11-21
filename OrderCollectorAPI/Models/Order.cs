using Newtonsoft.Json;
using OrderCollectorAPI.Models;

namespace OrderCollectorAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        [JsonProperty("orderid")]
        public int OrderId { get; set; }
        [JsonProperty("customerid")]
        public int CustomerId { get; set; }
        [JsonProperty("customer")]
        public string CustomerName { get; set; }
        [JsonProperty("invaddr")]
        public string InvoiceAddress { get; set; }
        [JsonProperty("delivaddr")]
        public string DeliveryAddress { get; set; }
        [JsonProperty("deliverydate")]
        public DateTime DeliveryDate { get; set; }
        [JsonProperty("respsalesperson")]
        public string SellerName { get; set; }
        [JsonProperty("comment")]
        public string OrderComment { get; set; }
        [JsonProperty("totalprice")]
        public decimal OrderPrice { get; set; }
        [JsonProperty("products")]
        public List<OrderRow> OrderRows { get; set; }
    }
}