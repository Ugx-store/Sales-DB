using System;

namespace Models
{
    public class Sale
    {
        public int Id { get; set; }
        public string SellerName { get; set; }
        public long SellerPhoneNumber { get; set; }
        public string BuyerName { get; set; }
        public long BuyerPhoneNumber { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public DateTime PurchaseDateTime { get; set; }
    }
}
