using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WC.Controller.Services.Contract;
using WC.RestAPI.Model.Login.Request;

namespace WC.RestAPI.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _service;
        private readonly IConfiguration _config;

        public LoginController(IMapper mapper, IUserService service, IConfiguration config)
        {
            this._mapper = mapper;
            this._service = service;
            this._config = config;
        }

        // [HttpPost]
        // public ActionResult Register()
        // {

        // }

        [HttpPost]
        public IActionResult Login(AuthUserRequest request)
        {
            var userFounded = this._service.Login(request.UserName, request.Password);

            if (userFounded == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFounded.Id.ToString()),
                new Claim(ClaimTypes.Name, userFounded.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token")));
        }
    }
}