using System;
using System.Collections.Generic;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.CustomExceptions;

namespace Tests.Core {
	[TestClass]
	public class EmployeeTests {
		EmployeeRepository EmployeeRepository = new EmployeeRepository();
        Database DB = new Database();

        [TestMethod]
        public void TestSaveEmployeeInRepository()
        {
            Address Address_A = new Address(38, "Grønløkkevej", 6800, "Odense");
            Employee A = new Employee(1, "test@example.com", "1234", "Test", "User", Address_A, "12344567", Permissions.Employee);

            EmployeeRepository.SaveEmployee(A);
            List<Employee> EmployeeList = EmployeeRepository.GetEmployees();

            bool EmployeeFound = false;

            foreach (Employee X in EmployeeList)
            {
                Address XA = X.Address;
                if (
                    X.ID == A.ID
                && X.Email == A.Email
                && X.Firstname == A.Firstname
                && X.Lastname == A.Lastname
                && X.Phone == A.Phone
                && X.Password == A.Password
                && X.Permissions == A.Permissions
                && XA.HouseNo == Address_A.HouseNo
                && XA.Streetname == Address_A.Streetname
                && XA.PostCode == Address_A.PostCode
                && XA.City == Address_A.City
                ) { EmployeeFound = true; }
            }
        }

		[TestMethod]
		public void TestLogin() {
			Address Address_A = new Address(38, "Grønløkkevej", 5000, "Odense");
			Employee A = new Employee(1, "test@example.com", "1234", "Test", "User", Address_A, "12344567", Permissions.Employee);
			EmployeeRepository.SaveEmployee(A);

			Address Address_B = new Address(1, "Grønløkkevej", 5000, "Odense");
			Employee B = new Employee(2, "test2@example.com", "1235", "Test2", "User2", Address_B, "23456789", Permissions.Manager);
			EmployeeRepository.SaveEmployee(B);

			Employee AL = EmployeeRepository.Login("test@example.com", "1234");

			Assert.AreEqual(A, AL);
		}

		[TestMethod]
		public void TestLoginNoUser() {
			Address Address_A = new Address(38, "Grønløkkevej", 5000, "Odense");
			Employee A = new Employee(1, "test@example.com", "1234", "Test", "User", Address_A, "12344567", Permissions.Employee);
			EmployeeRepository.SaveEmployee(A);

			Address Address_B = new Address(1, "Grønløkkevej", 5000, "Odense");
			Employee B = new Employee(2, "test2@example.com", "1235", "Test2", "User2", Address_B, "23456789", Permissions.Manager);
			EmployeeRepository.SaveEmployee(B);

			try {
				Employee AL = EmployeeRepository.Login("tes3t@example.com", "1234");
				Assert.IsTrue(false);
			} catch(InvalidLoginException) {
				Assert.IsTrue(true);
			}
		}


		[TestMethod]
		public void TestCanUpdateEmployee() {
			Address Address_A = new Address(38, "Grønløkkevej", 5000, "Odense");
			Employee A = new Employee(1, "test@example.com", "1234", "Test", "User", Address_A, "12344567", Permissions.Manager);
			EmployeeRepository.SaveEmployee(A);

			EmployeeRepository.Update(1, "Firstname", "NewFirstName");
			EmployeeRepository.Update(1, "Lastname", "NewLastName");
			EmployeeRepository.Update(1, "Email", "new@email.com");

			Employee B = EmployeeRepository.GetEmployee(1);
			Assert.AreEqual(B.Firstname, "NewFirstName");


		}

		[TestMethod]
		public void TestCanDeleteEmployee() {
			Address Address_A = new Address(38, "Grønløkkevej", 5000, "Odense");
			Employee A = new Employee(1, "test@example.com", "1234", "Test", "User", Address_A, "12344567", Permissions.Manager);
			EmployeeRepository.SaveEmployee(A);

			Assert.IsTrue(EmployeeRepository.Delete(1));
		}

        [TestCleanup]
        public void ClearDatabase()
        {
            DB.RunSP("usp_TruncateEmployees");
        }
    }
}
