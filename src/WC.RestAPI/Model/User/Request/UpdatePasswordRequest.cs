using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.RestAPI.Model.User.Request
{
    public class UpdatePasswordRequest
    {
        public long UserId { get; set; }
        public String NewPassword { get; set; }
    }
}
