using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
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
