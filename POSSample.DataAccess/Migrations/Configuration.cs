namespace POSSample.DataAccess.Migrations
{
    using POSSample.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<POSSample.DataAccess.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(POSSample.DataAccess.ApplicationDbContext context)
        {
            context.Customers.AddOrUpdate(
                c => c.Name,
                new Customer { Name = "Dagmawi Yitbarek", Email = "dagi.bro@yahoo.com", Phone = "026044817", TIN = "JKQTR98765432" },
                new Customer { Name = "Michael Gashaw", Email = "gashaw.mic@yahoo.com", Phone = "026044817", TIN = "JKQTR98765432" },
                new Customer { Name = "Leabkiber GEtachew", Email = "lala@yahoo.com", Phone = "026044817", TIN = "JKQTR98765432" },
                new Customer { Name = "Nardos Zebene", Email = "nardos.zebene@yahoo.com", Phone = "026044817", TIN = "JKQTR98765432" }
                );
        }
    }
}
