using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CustomerProductClasses
{
    public static class CustomerDB
    {

        private const string Path = @"..\..\..\data\Customers.xml";
        
        public static List<Customer> GetCustomers()
        {
            // create the list
            List<Customer> customers = new List<Customer>();

            // create the XmlReaderSettings object
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

            // create the XmlReader object
            XmlReader xmlIn = XmlReader.Create(Path, settings);

            // read past all nodes to the first Customer node
            if (xmlIn.ReadToDescendant("Customer"))
            {
                // create one Product object for each Product node
                do
                {
                    Customer customer = new Customer();
                    xmlIn.ReadStartElement("Customer");
                    customer.First = xmlIn.ReadElementContentAsString();
                    customer.Last = xmlIn.ReadElementContentAsString();
                    customer.Email = xmlIn.ReadElementContentAsString();
                    customer.Phone = xmlIn.ReadElementContentAsInt();
                    
                    customers.Add(customer);
                }
                while (xmlIn.ReadToNextSibling("Customer"));
            }

            // close the XmlReader object
            xmlIn.Close();

            return customers;
        }

        public static void SaveCustomers(List<Customer> customers)
        {
            // create the XmlWriterSettings object
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");

            // create the XmlWriter object
            XmlWriter xmlOut = XmlWriter.Create(Path, settings);

            // write the start of the document
            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("Customers");

            // write each product object to the xml file
            foreach (Customer customer in customers)
            {
                xmlOut.WriteStartElement("Customer");
                xmlOut.WriteElementString("First Name", customer.First);
                xmlOut.WriteElementString("Last Name", customer.Last);
                xmlOut.WriteElementString("Email", customer.Email);
                xmlOut.WriteElementString("Phone number", customer.Phone.ToString());
                
                xmlOut.WriteEndElement();
            }

            // write the end tag for the root element
            xmlOut.WriteEndElement();

            // close the xmlWriter object
            xmlOut.Close();
        }
        
    }
}