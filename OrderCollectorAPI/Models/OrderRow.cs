namespace OrderCollectorAPI.Models
{
    public class OrderRow
    {
        public int id { get; set; }
        public string code { get; set; }
        public string product { get; set; }
        public string description { get; set; }
        public string supplierCode { get; set; }
        public decimal amount { get; set; }
        public decimal unitPrice { get; set; }
        public string shelf { get; set; }
    }
}
