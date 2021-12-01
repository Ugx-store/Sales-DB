using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string SellerName { get; set; }
        public string BuyerName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public DateTime CartDateTime { get; set; }
    }
}
