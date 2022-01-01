using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderCollectorAPI.Models
{
    public class OrderRow
    {
        public int Id { get; set; }
        [ForeignKey("orders")]
        public int orderId { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("product")]
        public string Product { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("suppliercode")]
        public string SupplierCode { get; set; }
        [JsonProperty("qty")]
        public decimal Amount { get; set; }
        [JsonProperty("unit_price")]
        public decimal UnitPrice { get; set; }
        [JsonProperty("shelf_pos")]
        public string Shelf { get; set; }
        public string CollectorComment { get; set; } = string.Empty;
    }
}
