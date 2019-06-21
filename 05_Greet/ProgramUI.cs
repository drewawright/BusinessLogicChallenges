using _05_GreetRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greet
{
    public class ProgramUI
    {
        private GreetRepository _customerList = new GreetRepository();

        public void Run()
        {
            SeedCustomerList();
            RunUI();
        }

        private void RunUI()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Komodo Customer Mass Email System\n" +
                    "What would you like to do?\n" +
                    "1. See everyone on the list\n" +
                    "2. Add a new customer\n" +
                    "3. Update an existing customer\n" +
                    "4. Remove a customer\n" +
                    "5. Exit");
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        ShowCustomerList();
                        break;
                    case "2":
                        AddCustomer();
                        break;
                    case "3":
                        UpdateCustomer();
                        break;
                    case "4":
                        RemoveCustomer();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number from 1-5");
                        break;
                }
            }
        }

        private void ShowCustomerList()
        {
            List<Customer> customerList = _customerList.GetCustomerList();
            customerList.Sort();
            foreach(Customer customer in customerList)
            {
                Console.WriteLine($"{customer.FirstName, 8} {customer.LastName, 12} - {customer.TypeOfCustomer, 9}    {customer.Greet()}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void AddCustomer()
        {
            Console.Write("Please enter the first name of the customer you would like to add: ");
            string addFirst = Console.ReadLine();
            Console.Write("Please enter the last name of the customer you would like to add: ");
            string addLast = Console.ReadLine();
            Console.Write("What type of customer is this (1 - Current, 2 - Past, or 3 - Potential)? ");
            int addType = int.Parse(Console.ReadLine());
            CustomerType addCustomerType = (CustomerType)addType;
            Customer newCustomer = new Customer(addFirst, addLast, addCustomerType);
            _customerList.AddCustomerToList(newCustomer);
            Console.WriteLine("Customer added\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }

        private void UpdateCustomer()
        {
            Console.Write("Enter the existing first name of the customer to update: ");
            string existingFirst = Console.ReadLine();
            Console.Write("Enter the existing last name of the customer to update: ");
            string existingLast = Console.ReadLine();
            Console.Write("Enter the customer's updated first name: ");
            string updateFirst = Console.ReadLine();
            Console.Write("Enter the customer's updated last name: ");
            string updateLast = Console.ReadLine();
            Console.Write("Enter the customer's updated type (1 - current, 2 - past, 3 - potential): ");
            int updatedType = int.Parse(Console.ReadLine());
            CustomerType updatedCustomerType = (CustomerType)updatedType;
            Customer customer = new Customer(updateFirst, updateLast, updatedCustomerType);
            _customerList.UpdateCustomer(existingFirst, existingLast, customer);
            Console.WriteLine("Customer updated\n" +
                "Press any key to continue");
        }

        private void RemoveCustomer()
        {
            Console.Write("Enter the first name of the customer to remove: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter the last name of the customer to remove: ");
            string lastName = Console.ReadLine();
            _customerList.DeleteCustomerOnList(firstName, lastName);
            Console.WriteLine("Customer deleted\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }

        private void SeedCustomerList()
        {
            Customer customerOne = new Customer("James", "Smith", CustomerType.Current);
            Customer customerTwo = new Customer("Jake", "Smith", CustomerType.Potential);
            Customer customerThree = new Customer("Jane", "Smith", CustomerType.Past);

            _customerList.AddCustomerToList(customerOne);
            _customerList.AddCustomerToList(customerTwo);
            _customerList.AddCustomerToList(customerThree);
        }
    }
}
