using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.RestAPI.DTO
{
    public class User
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public String Pass { get; set; }
        public String Mail { get; set; }
        public DateTimeOffset DateOfCreation { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public String ActivationCode { get; set; }
        public Boolean Active { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
