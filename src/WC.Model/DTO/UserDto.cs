using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.Model.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public String Mail { get; set; }
        public DateTimeOffset DateOfCreation { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public int RoleId { get; set; }
        public RoleDto Role { get; set; }
    }
}
