using DAL.Models;
using DAL.Repositories;
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
       private readonly ProductsRepository _productService;
        public ProductsController(IUnityContainer container)
        {
           _productService = container.Resolve<ProductsRepository>();
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
        [Route("Update/{id}")]
        public IActionResult UpdateProduct(int id, Products product)
        {
            //var productObject = _productService.GetById(id);
           // if (productObject == null || product.Id != id)
           if (product.Id != id)
            {
                return BadRequest("ID is not matched");
            }
            _productService.Update(product);
            _productService.Save();
            return GetById(id);
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
