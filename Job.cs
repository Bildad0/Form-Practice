using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserFormApp
{
   public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }

        public string JobTitle { get; set; }

        public string JobDesc { get; set; }

        public string JobDepartments { get; set; }

        ////another convention to set one t0 many relationship between the entities.
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
