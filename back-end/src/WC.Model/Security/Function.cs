using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model.Security
{
    [Table("Function")]
    public class Function {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}