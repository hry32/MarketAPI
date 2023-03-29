using MarketApi.Domain.Models;
using MarketApi.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity;

namespace MarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {

        private readonly IRepository<Products> _productService;
        public ProductsController(IRepository<Products> productService)
        {
            this._productService = productService;
        }

        //GET All Person  
        //[HttpGet]
        [HttpPost]
        [Route("Get")]
        public IActionResult GetAllProducts()
        {
            var data = _productService.GetAll();
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
        public IActionResult AddProduct([FromBody] Products product)
        {
            try
            {
                _productService.Add(product);
                _productService.Save();
                return GetAllProducts();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [HttpDelete("{id}")]
        // [HttpPost("{id}")]
        [HttpPost]
        [Route("Del")]
        public IActionResult DeleteProduct(Products id)
        {
            try
            {
                _productService.Delete(id);
                _productService.Save();
                return GetAllProducts();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
         
        //[HttpPut("{id}")]
        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateProduct(Products product)
        {
            try
            {
                _productService.Update(product);
                _productService.Save();
                return GetById(product.Id);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }

        }

        [HttpPost]
        [Route("Get/{Id}")]
        public IActionResult GetById(int Id)
        {
            var data = _productService.GetById(Id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return Ok(json);
        }

    }
}
