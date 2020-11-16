using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WC.RestAPI.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WC.RestAPI.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService service;

        public UserController(IMapper mapper, IUserService service)
        {
            this._mapper = mapper;
            this.service = service;
        }

        [HttpGet("/GetById")]
        public ActionResult GetById(int id)
        {
            var user = _mapper.Map<User>(service.GetUser(id));
            return Ok(user);
        }

        [HttpGet("/GetUsers")]
        public ActionResult GetUsers()
        {
            var users = _mapper.Map<IEnumerable<User>>(service.GetUsers());
            return Ok(users);
        }

        // POST api/<UserController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
