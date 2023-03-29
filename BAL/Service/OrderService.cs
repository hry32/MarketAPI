using BAL.DTO;
using DAL.Data;
using MarketApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using BAL.Interfaces;
using Newtonsoft.Json;

namespace BAL.Service
{
    public class OrderService: IOrderService
    {
        AppDbContext _dbContext;        
        public OrderService(AppDbContext applicationDbContext )
        {
            _dbContext = applicationDbContext;          
        }
        public void Add(Orders order)
        {
            decimal productAmount = 0;
            var orderCustomer = order.Customer;            
            var userExist = _dbContext.Users.Where(x => x.UserName == orderCustomer).FirstOrDefault();
            var orderProductDetails = order.ProductDetails.ToList();
            if (userExist != null)
            {
                foreach (var ProductInOrder in orderProductDetails)
                {
                    var product = _dbContext.Products.Where(x => x.Id == ProductInOrder.productId).FirstOrDefault();
                    if (product is null)
                    {
                        throw new Exception(JsonConvert.SerializeObject("The product does not exist"));
                    }
                    else
                    {
                        if (product.Count - ProductInOrder.count < 0)
                        {
                            throw new Exception(JsonConvert.SerializeObject("Not enough product"));
                        }
                        product.Count -= ProductInOrder.count;
                        productAmount = ProductInOrder.count * product.Price;
                        order.OrderAmount += productAmount;                        
                        _dbContext.Orders.Add(order);
                    }
                    
                }
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception(JsonConvert.SerializeObject("Unknown user"));
            }
        }
        /********************************************************/

        public IEnumerable<OrdersDto> FindAll()
        {
            //  return db.Books.Include(b => b.Author).Select(AsBookDto);
            var orders = (from order in _dbContext.Orders
                          select new OrdersDto()
                          {
                              OrderId = order.Id,
                              Customer = order.Customer,
                              OrderAmount = order.OrderAmount
                          }).ToList();
            foreach (OrdersDto ordersDto in orders)
            {
                var orderDetails = from detail in _dbContext.OrderDetails
                                   where detail.orderId == ordersDto.OrderId
                                   select new OrderDetailsDto()
                                   {
                                       productName = detail.product.Name,
                                       count = detail.count,
                                       productPrice = detail.product.Price
                                                                          
                                   };
                ordersDto.ProductDetails = orderDetails;

            }
            return orders;
        }



        /****************************************************/
        public IEnumerable<OrdersDto> FindOrderById(int Id)
        {
            var orders = (from order in _dbContext.Orders
                          where order.Id == Id
                          select new OrdersDto()
                          {
                              OrderId = order.Id,
                              Customer = order.Customer,
                              OrderAmount = order.OrderAmount
                          }).ToList();
            foreach (OrdersDto ordersDto in orders)
            {
                var orderdetails = from detail in _dbContext.OrderDetails
                                   where detail.orderId == ordersDto.OrderId
                                   select new OrderDetailsDto()
                                   {
                                       productName = detail.product.Name,
                                       count = detail.count,
                                       productPrice = detail.product.Price
                                   };
                ordersDto.ProductDetails = orderdetails;

            }
            return orders;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }

}
