using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model.Security
{
    [Table("User")]
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
    }
}