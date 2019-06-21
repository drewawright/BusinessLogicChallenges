using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_GreetRepository
{
    public class GreetRepository
    {
        private List<Customer> _customerRepo = new List<Customer>();

        public List<Customer> GetCustomerList()
        {
            return _customerRepo;
        }

        public Customer GetOneCustomer(string firstName, string lastName)
        {
            foreach (Customer customer in _customerRepo)
            {
                if (firstName == customer.FirstName && lastName == customer.LastName)
                {
                    return customer;
                }
            }
            return null;
        }

        public void AddCustomerToList(Customer customer)
        {
            _customerRepo.Add(customer);
        }

        public void DeleteCustomerOnList(string firstName, string lastName)
        {
            Customer deletedCustomer = GetOneCustomer(firstName, lastName);
            _customerRepo.Remove(deletedCustomer);
        }

        public void UpdateCustomer(string firstName, string lastName, Customer newCustomer)
        {
            Customer updateCustomer = GetOneCustomer(firstName, lastName);
            updateCustomer.FirstName = newCustomer.FirstName;
            updateCustomer.LastName = newCustomer.LastName;
            updateCustomer.TypeOfCustomer = newCustomer.TypeOfCustomer;
        }
    }
}
