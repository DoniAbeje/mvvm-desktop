using POSSample.DataAccess;
using POSSample.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSample.UI.Data
{
    public class CustomerDataService : ICustomerDataService
    {
        
        public async  Task<List<Customer>> GetAllAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return await ctx.Customers.AsNoTracking().ToListAsync();
            }
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            using(var ctx = new ApplicationDbContext())
            {
               
                ctx.Entry<Customer>(customer).State = EntityState.Added;
                await ctx.SaveChangesAsync();
                return customer;
            }
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            using (var ctx = new ApplicationDbContext())
            {
                
                ctx.Entry<Customer>(customer).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
                return customer;
            }
        }

        public async Task<Customer> DeleteCustomerAsync(Customer customer)
        {
            using (var ctx = new ApplicationDbContext())
            {
               
                ctx.Entry<Customer>(customer).State = EntityState.Deleted;
                await ctx.SaveChangesAsync();
                return customer;
            }
        }

        public async Task<List<Customer>> SearchCustomerAsync(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var customers = await ctx.Customers.Where(c => c.Name.Contains(name)).ToListAsync();
                
                return customers;
            }
        }
    }
}
