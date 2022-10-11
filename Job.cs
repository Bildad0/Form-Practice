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
            Users = new List<User>();
        }
        public int JobId { get; set; }

        public string JobTitle { get; set; }

        public string JobDesc { get; set; }

        ////another convention to set one t many relationship between the entities.
        public virtual ICollection<User> Users { get; set; }
    }
}
