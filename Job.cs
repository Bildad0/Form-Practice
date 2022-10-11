using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserFormApp
{
   public class Job
    {
       [Key]
       public int JobId { get; set; }

        public string JobTitle { get; set; }

        public string JobDesc { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
