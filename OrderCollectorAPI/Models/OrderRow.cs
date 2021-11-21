﻿using Newtonsoft.Json;

namespace OrderCollectorAPI.Models
{
    public class OrderRow
    {
        public int Id { get; set; }
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
    }
}
