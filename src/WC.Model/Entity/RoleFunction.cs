using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Model.Entity
{
    [Table("RoleFunction")]
    public class RoleFunction {
        public int Id { get; set; }
        public int RoleId { get; set; }
        
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        
        public int FunctionId { get; set; }

        [ForeignKey("FunctionId")]
        public Function Function { get; set; }   
    }
}