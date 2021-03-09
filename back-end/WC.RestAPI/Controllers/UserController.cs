using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WC.Model.DTO;
using WC.Model.Services.Contract;
using WC.RestAPI.Model.User.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WC.RestAPI.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _service;

        public UserController(IMapper mapper, IUserService service)
        {
            this._mapper = mapper;
            this._service = service;
        }

        [HttpGet("/GetById")]
        public ActionResult GetById(int id)
        {
            var user = _service.GetUser(id);
            return Ok(user);
        }

        [HttpGet("/GetUsers")]
        public ActionResult GetUsers()
        {
            var users = _service.GetUsers();
            return Ok(users);
        }

        [HttpPut("/UpdatePassword")]
        public ActionResult UpdatePassword(UpdatePasswordRequest request)
        {
            var userFounded = this._service.GetUser(request.UserId);
            if(userFounded == null)
            {
                return NotFound();   
            }
            this._service.UpdatePassword(userFounded, request.NewPassword);
            
            return Ok();
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
