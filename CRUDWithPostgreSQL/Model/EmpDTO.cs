using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWithPostgreSQL.Model
{
    [Table("emp", Schema ="public")]
    public class EmpDTO
    {
        [Key]
        public int empid { get; set; }
        public string empname { get; set; }
        public string email { get; set; }
        public int salary { get; set; }

    }
}
