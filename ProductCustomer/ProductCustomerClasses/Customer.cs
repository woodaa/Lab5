using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProductClasses
{
    public class Customer
    {
        private string firstName;
        private string lastName;
        private string email;
        private int phoneNumber;




        public Customer() { }

        public Customer(string firstName, string lastName, string email, int phoneNumber)
        {
            firstName = First;
            lastName = Last;
            email = Email;
            phoneNumber = Phone;
            
        }

        public string First
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string Last
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public int Phone
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        

        public override string ToString()
        {
            return String.Format($"First: {0} Last: {1} Email: {2} Phone: {3:C}: " +
                                $"{4}", firstName, lastName, email, phoneNumber);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            else
            {
                Customer other = (Customer)obj;
                return other.First == First &&
                    other.Last == Last &&
                    other.Email == Email &&
                    other.Phone == Phone;
                    
            }
        }

        public override int GetHashCode()
        {
            return 13 + 7 * firstName.GetHashCode() +
                7 * lastName.GetHashCode() +
                7 * email.GetHashCode() +
                7 * phoneNumber.GetHashCode();
               
        }


        public static bool operator ==(Customer p1, Customer p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Customer p1, Customer p2)
        {
            return !p1.Equals(p2);
        }

    }
}
