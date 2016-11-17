using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Core {
	[TestClass]
	class Login {
		EmployeeRepository EmployeeRepository;

		[TestInitialize]
		private void SetUp() {
			EmployeeRepository = new EmployeeRepository();
		}
		
		[TestMethod]
		public void TestSaveEmployeeInRepository() {
			Address Address_A = new Address(38, "Grønløkkevej", 6800, "Odense");
			Employee A = new Employee(1, "test@example.com", "1234", "Test", "User", Address_A, "12344567");

			EmployeeRepository.SaveEmployee(A);

			var EmployeeList = EmployeeRepository.GetEmployees();
			Assert.IsTrue(EmployeeList.Contains(A));
		}

		[TestMethod]
		public void TestLogin() {
			Address Address_A = new Address(38, "Grønløkkevej", 6800, "Odense");
			Employee A = new Employee(1, "test@example.com", "1234", "Test", "User", Address_A, "12344567");
			
		}

	}
}
