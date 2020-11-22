using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model.Entity
{
    [Table("Role")]
    public class Role {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}