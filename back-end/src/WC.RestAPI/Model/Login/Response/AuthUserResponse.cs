using WC.Model.DTO;

namespace WC.RestAPI.Model.Login.Response
{
    public class AuthUserResponse
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}