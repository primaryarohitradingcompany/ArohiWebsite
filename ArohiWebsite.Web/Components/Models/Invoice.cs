namespace ArohiWebsite.Web.Components.Models
{
    public class InvoiceModel
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount => Quantity * Price;
        public string PaymentStatus { get; set; }
    }

}
