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
				case "1": CreateCustomer();	break;
				case "2": UpdateCustomer(); break;
				case "3": DeleteCustomer(); break;

				case "0": return;
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

			Console.Write("\nFirstname: ");		string Firstname = Program.GetInput("text");
			Console.Write("\nLastname: ");		string Lastname = Program.GetInput("text");
			Console.Write("\nEmail: ");			string Email = Program.GetInput("email");
			Console.Write("\nPhone: ");			string Phone = Program.GetInput("phone");
			Console.Write("\nHouse Number:");	int HouseNo = int.Parse(Program.GetInput("number"));
			Console.Write("\nFloor Number:");	int FloorNo = int.Parse(Program.GetInput("number"));
			Console.Write("\nEntrance:");		string Entrance = Program.GetInput("text");
			Console.Write("\nStreetname:");		string Streetname = Program.GetInput("text");
			Console.Write("\nCity:");			string City = Program.GetInput("text");
			Console.Write("\nPostCode:");		int PostCode = int.Parse(Program.GetInput("text"));

			Address Addr = new Address(HouseNo, FloorNo, Entrance, Streetname, PostCode, City);
			Customer Customer = new Customer(RepoCus.NextID(), Email, Firstname, Lastname, Addr, Phone);

			RepoCus.SaveCustomer(Customer);
		}

		internal void ShowCustomers() {
			throw new NotImplementedException();
		}

	}
}
