using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserFormApp
{
   
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }


        public int UserAge { get; set; }

        [Required]
        public string UserEmail { get; set; }

        public string UserCity { get; set; }

        public string JobTitle { get; set; }
        public Job job { get; set; }

    }
}
