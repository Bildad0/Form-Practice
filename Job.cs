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

        public Job()
        {
            this.Users = new HashSet<User>();
            this.Departments = new HashSet<Department>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }

        public string JobTitle { get; set; }

        public string JobDesc { get; set; }

        public string JobDepartments { get; set; }

        ////another convention to set one t many relationship between the entities.
        public virtual ICollection<User> Users { get; set; } = new List<User>();
        public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}
