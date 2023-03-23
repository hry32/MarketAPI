using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.DTO
{
    public class OrdersDto
    {
            public int OrderId { get; set; }
            public string Customer { get; set; }
            public decimal OrderAmount { get; set; }
            public IEnumerable<OrderDetailsDto> ProductDetails { get; set; }
        
    }
}
