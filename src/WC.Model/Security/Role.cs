using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model.Security
{
    [Table("Role")]
    public class Role {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}