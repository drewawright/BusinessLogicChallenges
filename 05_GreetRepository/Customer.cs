using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_GreetRepository
{
    public enum CustomerType
    {
        Current = 1,
        Past,
        Potential
    }
    public class Customer : IComparable<Customer>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType TypeOfCustomer { get; set; }

        public virtual string Greet()
        {
            switch (TypeOfCustomer)
            {
                case CustomerType.Current:
                    return "Thanks for your loyalty. We'd like to show our appreciation with this coupon!";
                case CustomerType.Past:
                    return "We haven't heard from you in a while. Please check out these new services we offer.";
                case CustomerType.Potential:
                    return "We have the lowest rates on helicopter insurance";
                default:
                    return "We'd like to know you better";
            }
        }

        public Customer()
        {
            TypeOfCustomer = CustomerType.Current;
        }

        public Customer(string firstName, string lastName, CustomerType customerType)
        {
            FirstName = firstName;
            LastName = lastName;
            TypeOfCustomer = customerType;
        }

        public int CompareTo(Customer other)
        {
            int ret = this.LastName.CompareTo(other.LastName);
            if (ret == 0)
            {
                ret = this.FirstName.CompareTo(other.FirstName);
            }
            return ret;
        }
    }
}
