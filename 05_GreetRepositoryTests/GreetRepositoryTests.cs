using System;
using System.Collections.Generic;
using _05_GreetRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_GreetRepositoryTests
{
    [TestClass]
    public class GreetRepositoryTests
    {
        private GreetRepository _customerRepo;
        private Customer _customer;

        [TestInitialize]
        public void Arrange()
        {
            _customerRepo = new GreetRepository();
            _customer = new Customer("James", "Smith", CustomerType.Current);
            _customerRepo.AddCustomerToList(_customer);
        }

        [TestMethod]
        public void AddCustomerToListTest()
        {
            Customer customerTwo = new Customer("Jane", "Smith", CustomerType.Past);
            _customerRepo.AddCustomerToList(customerTwo);

            int expected = 2;
            int actual = _customerRepo.GetCustomerList().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCustomerListTest()
        {
            Assert.IsInstanceOfType(_customerRepo.GetCustomerList(), typeof(List<Customer>));
        }

        [TestMethod]
        public void GetOneCustomerTest()
        {
            Customer test = _customerRepo.GetOneCustomer("James", "Smith");

            Assert.AreEqual("James", test.FirstName);
            Assert.AreEqual("Smith", test.LastName);
            Assert.AreEqual(CustomerType.Current, test.TypeOfCustomer);
        }

        [TestMethod]
        public void DeleteCustomerTest()
        {
            _customerRepo.DeleteCustomerOnList("James", "Smith");

            int expected = 0;
            int actual = _customerRepo.GetCustomerList().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateCustomerTest()
        {
            Customer newJames = new Customer("James", "Smith-Jones", CustomerType.Potential);
            _customerRepo.UpdateCustomer("James", "Smith", newJames);

            var actual = _customerRepo.GetOneCustomer("James", "Smith-Jones");

            Assert.AreEqual(newJames.FirstName, actual.FirstName);
            Assert.AreEqual(newJames.LastName, actual.LastName);
            Assert.AreEqual(newJames.TypeOfCustomer, actual.TypeOfCustomer);
        }
    }
}
