using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
            var userFounded = this._service.Login(request.Username, request.Password);

            if (userFounded == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFounded.Id.ToString()),
                new Claim(ClaimTypes.Name, userFounded.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}