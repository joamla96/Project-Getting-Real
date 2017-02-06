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
		Database DB = new Database();

        [TestMethod]
        public void TestSaveCustomerInRepository()
        {
			bool CustomerFound = false;
            Address Address_A = new Address(50, "Grønløkkevej", 5000, "Odense");
            Customer A = new Customer(1, "test@example.com", "Test", "User", Address_A, "12344567");

            CustomerRepository.SaveCustomer(A);
            List<Customer> CustomerList = CustomerRepository.GetCustomers();

            foreach(Customer X in CustomerList) {
				Address XA = X.Address;
				if(
					X.ID == A.ID
				&&	X.Email == A.Email
				&&	X.Firstname == A.Firstname
				&&	X.Lastname == A.Lastname
				&&	X.Phone == A.Phone

				&&	XA.HouseNo == Address_A.HouseNo
				&&	XA.Streetname == Address_A.Streetname
				&&	XA.PostCode == Address_A.PostCode
				&&	XA.City == Address_A.City
				) { CustomerFound = true; }
			}

			Assert.IsTrue(CustomerFound);
        }

        [TestMethod]
        public void TestCanUpdateCustomer()
        {
            Address Address_A = new Address(50, "Grønløkkevej", 5000, "Odense");
            Customer A = new Customer(1, "test@example.com", "Test", "User", Address_A, "12344567");
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
            Customer A = new Customer(1, "test@example.com", "Test", "User", Address_A, "12344567");
            CustomerRepository.SaveCustomer(A);

            Assert.IsTrue(CustomerRepository.Delete(1));
        }

		[TestCleanup]
		public void ClearDatabase() {
			//DB.RunSP("usp_TruncateCustomers");
		}
    }
}
