using System;
using System.Collections.Generic;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Core
{
    [TestClass]
    public class CustomerTests
    {
        CustomerRepository CustomerRepository = new CustomerRepository();

        [TestMethod]
        public void TestSaveCustomerInRepository()
        {
            Address Address_A = new Address(50, "Grønløkkevej", 5000, "Odense");
            Customer A = new Customer(1, "test@example.com", "1234", "Test", "User", Address_A, "12344567");

            CustomerRepository.SaveCustomer(A);
            List<Customer> CustomerList = CustomerRepository.GetCustomers();

            Assert.IsTrue(CustomerList.Contains(A));
        }

        [TestMethod]
        public void TestCanUpdateCustomer()
        {
            Address Address_A = new Address(50, "Grønløkkevej", 5000, "Odense");
            Customer A = new Customer(1, "test@example.com", "1234", "Test", "User", Address_A, "12344567");
            CustomerRepository.SaveCustomer(A);

            CustomerRepository.Update(1, "Firstname", "NewFirstName");
            CustomerRepository.Update(1, "Lastname", "NewLastName");
            CustomerRepository.Update(1, "Email", "new@email.com");

            Customer B = CustomerRepository.GetCustomer(1);
            Assert.AreEqual(B.Firstname, "NewFirstName");
        }

        [TestMethod]
        public void TestCanDeleteCustomer()
        {
            Address Address_A = new Address(50, "Grønløkkevej", 5000, "Odense");
            Customer A = new Customer(1, "test@example.com", "1234", "Test", "User", Address_A, "12344567");
            CustomerRepository.SaveCustomer(A);

            Assert.IsTrue(CustomerRepository.Delete(1));
        }
    }
}
