using BAL.Interfaces;
using MarketApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;


namespace MarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            this._orderService = orderService;
        }
       
        //GET All Person  
        [HttpGet]
        //[HttpPost]
        [Route("Get")]
        public IActionResult GetAllOrders()
        {
            var data = _orderService.FindAll();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return Ok(json);
        }
        [HttpPost]
        [Route("Get/{Id}")]
        public IActionResult GetOrdersById(int Id)
        {
            var data = _orderService.FindOrderById(Id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return Ok(json);
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult AddOrder([FromBody] Orders order)
        {
            try
            {
                _orderService.Add(order);
                return Ok(JsonConvert.SerializeObject("Order is added"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    }
