using BAL.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrdersDto> FindAll();
        IEnumerable<OrdersDto> FindOrderById(int Id);
        void Add(Orders _object);
        void Save();
    }
}
