using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WC.Model.DTO;
using WC.Model.Services.Contract;
using WC.RestAPI.Model.Login.Request;
using WC.RestAPI.Model.Login.Response;

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

        [HttpPost("/SignUpUser")]
        public ActionResult SignUpUser(RegisterUserRequest request)
        {
            if (_service.ExistUsername(request.UserName))
            {
                return BadRequest("The Username exist!");
            }

            var userDto = this._service.RegisterUser(_mapper.Map<UserDto>(request), request.Password);

            var token = GenerateToken(userDto);

            return Ok(new AuthUserResponse()
            {
                User = userDto,
                Token = token
            });
        }

        [HttpPost("/LoginUser")]
        public ActionResult Login(AuthUserRequest request)
        {
            var userFounded = this._service.Login(request.Username, request.Password);

            if (userFounded == null)
            {
                return Unauthorized();
            }

            String token = GenerateToken(userFounded);

            return Ok(new AuthUserResponse()
            {
                User = userFounded,
                Token = token
            });
        }

        private String GenerateToken(UserDto user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Token").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        //private async void SentActivationMail(UserDto user){
        //    string baseURL = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/Login/ActivateAccount/{user.ActivationCode}";
        //    var from = new MailAddress("mauro9410@gmail.com", "Activate your Account!");
        //    var to = new MailAddress(user.Mail);
        //    var frontEmailPassword = "your password";
        //    String subject = _config.GetSection("EmailTemplate::Subject").Value;
        //    String body = _config.GetSection("EmailTemplate::Body").Value;
        //    body = body + $"<a href='{baseURL}'>{baseURL}</a>";

        //    var smtp = new SmtpClient
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential(from.Address, frontEmailPassword)
        //    };

        //    using (var message = new MailMessage(from, to)
        //    {
        //        Subject = subject,
        //        Body = body,
        //        IsBodyHtml = true
        //    })
        //    {
        //        smtp.Send(message);
        //    }
        //}
    }
}