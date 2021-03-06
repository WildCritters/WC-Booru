using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model.Entity
{
    [Table("User")]
    public class User
    {
        [Key]
        public long Id { get; set; } 
        public String UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public String Mail { get; set; }
        public DateTimeOffset DateOfCreation { get; set; }
        public DateTimeOffset LastLoggedAt { get; set; }
        public DateTimeOffset LastForumReadAt { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public String ActivationCode { get; set; }
        public String TimeZone { get; set; }
        public String Ip { get; set; }
        public bool Active { get; set; }    
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}