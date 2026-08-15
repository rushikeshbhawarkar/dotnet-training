using aug_14.Models;

namespace aug_14.Repository
{
    public interface ICustomerService
    {
        List<Customer> GetCustomer();
        Customer? GetCustomerById(int id);
        Customer Add(Customer customer);

    }
}
