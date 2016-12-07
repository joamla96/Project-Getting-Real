using Core;
using System;

namespace Interface {
	internal class CustomerUI {
		EmployeeRepository RepoEmp = new EmployeeRepository();
		CustomerRepository RepoCus = new CustomerRepository();
		Program Program = new Program();

		internal void UpdateCustomerDatabase() {
			Console.WriteLine("Choose Your Updated Options\n" +
				"1. Create Customer \n" +
				"2. Update Customer \n" +
				"3. Delete Customer \n" +
				"0. Back");

			string userInput = Console.ReadLine();
			Console.Clear();

			switch (userInput) {
				case "1":
					CreateCustomer();
					break;

				case "2":
					UpdateCustomer();
					break;

				case "3":
					DeleteCustomer();
					break;

				case "0":
					return;
			}
		}

		private void DeleteCustomer() {
			throw new NotImplementedException();
		}

		private void UpdateCustomer() {
			throw new NotImplementedException();
		}

		private void CreateCustomer() {
			Console.Clear();
			Console.WriteLine("Create new Customer\n");

			Console.Write("Firstname: ");	string Firstname = Program.GetInput("text");
			Console.Write("Lastname: ");	string Lastname = Program.GetInput("text");
			Console.Write("Email: ");		string Email = Program.GetInput("email");
		}

		internal void ShowCustomers() {
			throw new NotImplementedException();
		}

	}
}
