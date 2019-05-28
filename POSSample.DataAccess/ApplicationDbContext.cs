using POSSample.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSample.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base("POSDB")
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
