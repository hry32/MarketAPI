using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarketApi.Domain.Models
{
    public class Orders
    {
        public int Id { get; set; }
        [Required]
        public string Customer { get; set; }
        public decimal OrderAmount { get; set; }
        public List<OrderDetails> ProductDetails { get; set; }
    }
}
