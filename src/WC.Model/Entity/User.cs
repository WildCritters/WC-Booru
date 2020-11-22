using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model.Entity
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; } 
        public String UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public String Mail { get; set; }
        public DateTimeOffset DateOfCreation { get; set; }
        public DateTimeOffset LastUpdate { get; set; }    
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}