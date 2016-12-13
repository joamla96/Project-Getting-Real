using Core;
using System;
using System.Collections.Generic;

namespace Interface
{
	internal class EmployeeUI
	{
		EmployeeRepository RepoEmp = new EmployeeRepository();
		//CustomerRepository RepoCus = new CustomerRepository();
		Program Program = new Program();

		internal void UpdateEmployeeDatabase()
		{
			bool InMenu = true;
			while (InMenu)
			{
				Console.Clear();
				Console.WriteLine("Choose Your Updated Options\n" +
					"1. Create Employee \n" +
					"2. Update Employee \n" +
					"3. Delete Employee \n" +
					"4. Show All Employees\n" +
					"\n0. Back");

				string userInput = Program.GetInput("number");
				Console.Clear();

				switch (userInput)
				{
					case "1": CreateEmployee(); break;
					case "2": UpdateEmployee(); break;
					case "3": DeleteEmployee(); break;
					case "4":
						ShowEmployees();
						Console.ReadKey();
						break;

					case "0": InMenu = false; break;
				}
			}
		}

		private void DeleteEmployee()
		{
			ShowEmployees();

			Console.Write("Type EmployeeID you would like to Delete: ");
			int EmployeeID = int.Parse(Program.GetInput("number"));

			Console.WriteLine("Are you sure to Delete this Employee? (Y/N)");
			string Menu = Program.GetInput("yn");

			switch (Menu.ToUpper())
			{
				case "Y":
					RepoEmp.Delete(EmployeeID);
					break;

				case "N":
					Console.WriteLine("Aborted Deletion...");
					Console.ReadKey();
					break;
			}
		}

		private void UpdateEmployee()
		{
			ShowEmployees();

			Console.Write("Type EmployeeID you would like to update: ");
			int EmployeeID = int.Parse(Program.GetInput("number"));

			bool UpdatingEmployee = true;
			while (UpdatingEmployee)
			{
				Console.Clear();
				Employee Original;

				try
				{
					Original = RepoEmp.GetEmployee(EmployeeID);
				}
				catch (NullReferenceException)
				{
					Original = null;
				}

				if (Original != null)
				{
					Console.WriteLine(Original.ToString());

					Console.WriteLine("\nWhat would you like to Update?");
					Console.WriteLine("1. Firstname");
					Console.WriteLine("2. Lastname");
					Console.WriteLine("3. Email");
					Console.WriteLine("4. Password");
					Console.WriteLine("5. Address");
					Console.WriteLine("6. Phone");
					Console.WriteLine("7. Permissions");


					Console.WriteLine("\n0. Exit");

					switch (Program.GetInput("number"))
					{
						case "1": UpdateEmployeeFirstname(Original); break;
						case "2": UpdateEmployeeLastname(Original); break;
						case "3": UpdateEmployeeEmail(Original); break;
						case "4": UpdateEmployeePassword(Original); break;
						case "5": UpdateEmployeeAddress(Original); break;
						case "6": UpdateEmployeePhone(Original); break;
						case "7": UpdateEmployeePermission(Original); break;


						case "0": UpdatingEmployee = false; break;
					}
				}
				else
				{
					Console.WriteLine("Invalid EmployeeID");

					Console.WriteLine("\nClick any key to return to menu");
					UpdatingEmployee = false;
					Console.ReadKey();
				}
			}
		}

		private void UpdateEmployeePhone(Employee original)
		{
			Console.WriteLine("Current Number: " + original.Phone);
			Console.Write("New Number:");
			string newPhone = Program.GetInput("phone");

			RepoEmp.Update(original.ID, "Phone", newPhone);
		}

		private void UpdateEmployeeAddress(Employee original)
		{
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
			RepoEmp.Update(original.ID, "Address", newAddress);
		}

		private void UpdateEmployeeEmail(Employee original)
		{
			Console.WriteLine("Current Email: " + original.Email);
			Console.Write("New Email:");
			string newEmail = Program.GetInput("email");

			RepoEmp.Update(original.ID, "Email", newEmail);
		}

		private void UpdateEmployeePassword(Employee original)
		{
			Console.WriteLine("Current Password: " + original.Password);
			Console.Write("New Password:");
			string newPassword = Program.GetInput("password");

			RepoEmp.Update(original.ID, "Password", newPassword);
		}

		private void UpdateEmployeePermission(Employee original)
		{
			Console.WriteLine("Current Permission: " + original.Permissions);
			Console.Write("New Permission:");
			string newPermission = Program.GetInput("permission");

			RepoEmp.Update(original.ID, "Permission", newPermission);
		}

		private void UpdateEmployeeLastname(Employee original)
		{
			Console.WriteLine("Current Lastname: " + original.Lastname);
			Console.Write("New Lastname:");
			string newLastname = Program.GetInput("text");

			RepoEmp.Update(original.ID, "Lastname", newLastname);
		}

		private void UpdateEmployeeFirstname(Employee original)
		{
			Console.WriteLine("Current Firstname: " + original.Firstname);
			Console.Write("New Firstname:");
			string newFirstname = Program.GetInput("text");

			RepoEmp.Update(original.ID, "Firstname", newFirstname);
		}

		private void CreateEmployee()
		{
			Console.Clear();
			Console.WriteLine("Create new Employee\n");

			Console.Write("\nFirstname: "); string Firstname = Program.GetInput("text");
			Console.Write("\nLastname: "); string Lastname = Program.GetInput("text");
			Console.Write("\nEmail: "); string Email = Program.GetInput("email");
			Console.Write("\nPassword: "); string Password = Program.GetInput("password");
			Console.Write("\nPhone: "); string Phone = Program.GetInput("phone");
			Console.Write("\nHouse Number:"); int HouseNo = int.Parse(Program.GetInput("number"));
			Console.Write("\nFloor Number:"); int FloorNo = int.Parse(Program.GetInput("number"));
			Console.Write("\nEntrance:"); string Entrance = Program.GetInput("text");
			Console.Write("\nStreetname:"); string Streetname = Program.GetInput("text");
			Console.Write("\nCity:"); string City = Program.GetInput("text");
			Console.Write("\nPostCode:"); int PostCode = int.Parse(Program.GetInput("text"));
			Console.Write("\nPermission:"); int Permission = int.Parse(Program.GetInput("number"));


			Address Addr = new Address(HouseNo, FloorNo, Entrance, Streetname, PostCode, City);
			Employee Employee = new Employee(Email, Password, Firstname, Lastname, Addr, Phone, Permission);

			RepoEmp.SaveEmployee(Employee);
		}

		internal void ShowEmployees()
		{
			List<Employee> Employees = RepoEmp.GetEmployees();

			foreach (Employee e in Employees)
			{
				Console.WriteLine(e.ToString());
			}
		}

	}
}

/*using System;
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
}*/
