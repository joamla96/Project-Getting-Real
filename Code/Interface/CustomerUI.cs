using Core;
using System;
using System.Collections.Generic;

namespace Interface {
	internal class CustomerUI {
		EmployeeRepository RepoEmp = new EmployeeRepository();
		CustomerRepository RepoCus = new CustomerRepository();
		Program Program = new Program();

		internal void UpdateCustomerDatabase() {
			bool InMenu = true;
			while (InMenu) {
				Console.Clear();
				Console.WriteLine("Choose Your Updated Options\n" +
					"1. Create Customer \n" +
					"2. Update Customer \n" +
					"3. Delete Customer \n" +
					"4. Show All Cutomers\n" +
					"\n0. Back");

				string userInput = Program.GetInput("number");
				Console.Clear();

				switch (userInput) {
					case "1": CreateCustomer(); break;
					case "2": UpdateCustomer(); break;
					case "3": DeleteCustomer(); break;
					case "4":
						ShowCustomers();
						Console.ReadKey();
						break;

					case "0": InMenu = false; break;
				}
			}
		}

		private void DeleteCustomer() {
			ShowCustomers();

			Console.Write("Type ID of Customer you wish to Delete: ");
			int CustomerID = int.Parse(Program.GetInput("number"));

			Console.WriteLine("Are you sure you wish to delete this customer? (Y/N)");
			string Menu = Program.GetInput("yn");

			switch(Menu.ToUpper()) {
				case "Y":
					RepoCus.Delete(CustomerID);
					break;

				case "N":
					Console.WriteLine("Aborted Deletion...");
					Console.ReadKey();
					break;
			}
		}

		private void UpdateCustomer() {
			ShowCustomers();

			Console.Write("Type ID of Customer you wish to update: ");
			int CustomerID = int.Parse(Program.GetInput("number"));

			bool UpdatingCustomer = true;
			while (UpdatingCustomer) {
				Console.Clear();
				Customer Original;

				try {
					Original = RepoCus.GetCustomer(CustomerID);
				} catch(NullReferenceException) {
					Original = null;
				}

				if (Original != null) {
					Console.WriteLine(Original.ToString());

					Console.WriteLine("\nWhat do you want to update?");
					Console.WriteLine("1. Firstname");
					Console.WriteLine("2. Lastname");
					Console.WriteLine("3. Email");
					Console.WriteLine("4. Address");
					Console.WriteLine("5. Phone");

					Console.WriteLine("\n0. Exit");

					switch (Program.GetInput("number")) {
						case "1": UpdateCustomerFirstname(Original); break;
						case "2": UpdateCustomerLastname(Original); break;
						case "3": UpdateCustomerEmail(Original); break;
						case "4": UpdateCustomerAddress(Original); break;
						case "5": UpdateCustomerPhone(Original); break;

						case "0": UpdatingCustomer = false; break;
					}
				} else {
					Console.WriteLine("Invalid Customer ID.");

					Console.WriteLine("\nClick any key to return to menu.");
					UpdatingCustomer = false;
					Console.ReadKey();
				}
			}
		}

		private void UpdateCustomerPhone(Customer original) {
			Console.WriteLine("Current Number: " + original.Phone);
			Console.Write("New Number:");
			string newPhone = Program.GetInput("phone");

			RepoCus.Update(original.ID, "Phone", newPhone);
		}

		private void UpdateCustomerAddress(Customer original) {
			Console.WriteLine("Current Address:");
			Console.WriteLine(original.Address.ToString());

			Console.WriteLine("Input new Address:");
			Console.Write("HouseNo: "); int newHouseNo = int.Parse(Program.GetInput("number"));
			Console.Write("FloorNo: "); int newFloorNo = int.Parse(Program.GetInput("number"));
			Console.Write("Entrnace: "); string newEntrance = Program.GetInput("text");
			Console.Write("Streetname: "); string newStreetname = Program.GetInput("text");
			Console.Write("City: "); string newCity = Program.GetInput("text");
			Console.Write("PostCode: "); int newPostCode = int.Parse(Program.GetInput("number"));

			Address newAddress = new Address(newHouseNo, newFloorNo, newEntrance, newStreetname, newPostCode, newCity);
			RepoCus.Update(original.ID, "Address", newAddress);
		}

		private void UpdateCustomerEmail(Customer original) {
			Console.WriteLine("Current Email: " + original.Email);
			Console.Write("New Email:");
			string newEmail = Program.GetInput("email");

			RepoCus.Update(original.ID, "Email", newEmail);
		}

		private void UpdateCustomerLastname(Customer original) {
			Console.WriteLine("Current Lastname: " + original.Lastname);
			Console.Write("New Lastname:");
			string newLastname = Program.GetInput("text");

			RepoCus.Update(original.ID, "Lastname", newLastname);
		}

		private void UpdateCustomerFirstname(Customer original) {
			Console.WriteLine("Current Firstname: " + original.Firstname);
			Console.Write("New Firstname:");
			string newFirstname = Program.GetInput("text");

			RepoCus.Update(original.ID, "Firstname", newFirstname);
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
			Customer Customer = new Customer(Email, Firstname, Lastname, Addr, Phone);

			RepoCus.SaveCustomer(Customer);
		}

		internal void ShowCustomers() {
			List<Customer> Customers = RepoCus.GetCustomers();

			foreach(Customer C in Customers) {
				Console.WriteLine(C.ToString());
			}
		}

	}
}
