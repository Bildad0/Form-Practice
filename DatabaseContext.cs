using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserFormApp
{
    class DatabaseContext: DbContext
    {
        //1. You need to provide connection string to base class
        //2. You need to turn on migrations in your project
        //3. Call database initializer on application startup

        public DatabaseContext() : base("UniversityEntities")
        {
        }

        public DbSet<User> Users { get; set; }
    }


}
