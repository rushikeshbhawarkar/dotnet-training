using aug_14.Data;
using aug_14.Models;
using aug_14.Repository;

namespace aug_14.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext context;
        public CustomerService(AppDbContext context)
        {
            this.context = context;
        }
        public Customer Add(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return customer;
        }

        public List<Customer> GetCustomer()
        {
            return context.Customers.ToList();
        }

        public Customer? GetCustomerById(int id)
        {
            return context.Customers.Find(id);
        }
    }
}
