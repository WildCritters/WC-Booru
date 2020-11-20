using System;

namespace WC.RestAPI.Model.Login.Request
{
    public class RegisterUserRequest
    {
        public String UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public String Mail { get; set; }
        public DateTimeOffset DateOfCreation { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public String ActivationCode { get; set; }
        public Boolean Active { get; set; }
    }
}