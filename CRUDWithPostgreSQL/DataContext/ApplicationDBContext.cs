using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDWithPostgreSQL.Model;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithPostgreSQL.DataContext
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext()
        {

        }
        //public ApplicationDBContext() : base(nameOrConnectionString: "DefaultConnection")

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<EmpDTO> EmpObj { get; set; }
    }
}
