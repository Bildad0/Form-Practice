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
        public Department()
        {
            this.Jobs = new HashSet<Job>();
            this.Departments = new HashSet<Department>();
        }

        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentTitle { get; set; }

        public System.Data.Entity.Spatial.DbGeography DepartmentLocation { get; set; }


        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<Department> Departments { get;  set; }
        
    }
}
