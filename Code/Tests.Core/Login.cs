using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Core {
	[TestClass]
	public class Login {
		EmployeeRepository EmployeeRepository = new EmployeeRepository();
		
		[TestMethod]
		public void TestSaveEmployeeInRepository() {
			Address Address_A = new Address(38, "Grønløkkevej", 6800, "Odense");
			Employee A = new Employee(1, "test@example.com", "1234", "Test", "User", Address_A, "12344567");

			EmployeeRepository.SaveEmployee(A);
			List<Employee> EmployeeList = EmployeeRepository.GetEmployees();

			Assert.IsTrue(EmployeeList.Contains(A));
		}

		[TestMethod]
		public void TestLogin() {
			Address Address_A = new Address(38, "Grønløkkevej", 6800, "Odense");
			Employee A = new Employee(1, "test@example.com", "1234", "Test", "User", Address_A, "12344567");
			EmployeeRepository.SaveEmployee(A);

			Address Address_B = new Address(1, "Grønløkkevej", 6800, "Odense");
			Employee B = new Employee(2, "test2@example.com", "1235", "Test2", "User2", Address_B, "23456789");
			EmployeeRepository.SaveEmployee(B);

			Employee AL = EmployeeRepository.Login("test@example.com", "1234");

			Assert.AreEqual(A, AL);
		}


		[TestMethod]
		public void TestCanUpdateCustomer() {
			Address Address_A = new Address(38, "Grønløkkevej", 6800, "Odense");
			Employee A = new Employee(1, "test@example.com", "1234", "Test", "User", Address_A, "12344567");
			EmployeeRepository.SaveEmployee(A);

			EmployeeRepository.Update(1, "Firstname", "NewFirstName");

			Employee B = EmployeeRepository.GetEmployee(1);
			Assert.AreEqual(B.Firstname, "NewFirstName");
		}
	}
}
