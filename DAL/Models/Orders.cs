using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
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
