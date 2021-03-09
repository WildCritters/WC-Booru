using System;

namespace WC.RestAPI.Model.Login.Request
{
    public class RegisterUserRequest
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Mail { get; set; }
    }
}