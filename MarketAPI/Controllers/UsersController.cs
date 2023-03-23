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
    public class UsersController : Controller
    {
        private readonly UsersRepository _userService;
        public UsersController(IUnityContainer container)
        {
            _userService = container.Resolve<UsersRepository>();
        }
        /**********************************************/

        [HttpPost]
        [Route("Get")]
        public IActionResult GetAllUsers()
        {
            var data = _userService.GetAll();
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
        public IActionResult AddPerson([FromBody] Users user)
        {
            try
            {
                _userService.Add(user);
                _userService.Save();
                return GetAllUsers();
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
        public IActionResult DeletePerson(Users id)
        {
            try
            {
                _userService.Delete(id);
                _userService.Save();
                return GetAllUsers();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //[HttpPut("{id}")]
        [HttpPost]
        [Route("Update")]
        public IActionResult UpdatePerson(Users person)
        {
            try
            {
                _userService.Update(person);
                _userService.Save();
                return GetById(person.Id);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }


        }
        // [HttpGet("{Id}")]
        [HttpPost]
        [Route("Get/{Id}")]
        public IActionResult GetById(int Id)
        {
            var data = _userService.GetById(Id);
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
