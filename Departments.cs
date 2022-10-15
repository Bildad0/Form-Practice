using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserFormApp
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentTitle { get; set; }

        public System.Data.Entity.Spatial.DbGeography DepartmentLocation { get; set; }
        
    }
}
