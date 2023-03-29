using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApi.Domain.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public int count { get; set; }
        public Orders order { get; set; }
        public Products product { get; set; }
    }
}
