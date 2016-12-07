using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface {
	internal class EmployeeUI {
		internal void UpdateEmployeeDatabase() {
			Console.WriteLine("Choose Your Updated Options\n" +
				"1. Create Employee \n" +
				"2. Update Employee \n" +
				"3. Delete Employee \n" +
				"0. Back");

			string userInput = Console.ReadLine();
			Console.Clear();

			switch (userInput) {
				case "1":
					CreateEmployee();
					break;

				case "2":
					UpdateEmployee();
					break;

				case "3":
					DeleteEmployee();
					break;

				case "0":
					return;
			}
		}

		private void DeleteEmployee() {
			throw new NotImplementedException();
		}

		private void UpdateEmployee() {
			throw new NotImplementedException();
		}

		private void CreateEmployee() {
			throw new NotImplementedException();
		}

		internal void ShowEmployees() {
			throw new NotImplementedException();
		}
	}
}
