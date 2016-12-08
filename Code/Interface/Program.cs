using System;
using System.Collections.Generic;
using Core;
using System.Security;
using Core.CustomExceptions;

namespace Interface {
	internal class Program {
		Dictionary<int, string> CB = new Dictionary<int, string>(); // Console Buffer
		Employee LoggedIn;

		EmployeeRepository RepoEmp = new EmployeeRepository();
		CustomerRepository RepoCus = new CustomerRepository();
		private static void Main() {
			Program myProgram = new Program();
			myProgram.Run();
		}

		internal void Run() {
			while (true) {
				//while (LoggedIn == null) {
				//	Login();
				//}
				Console.Clear();
				Console.WriteLine("Main Menu\n");
				Console.WriteLine("Please Choose Your Option");
				Console.WriteLine("1. Search Customer Database");
				Console.WriteLine("2. Search Employee Database ");
				Console.WriteLine("3. Edit Customer Databasen");
				Console.WriteLine("4. Edit Employee Database");
				Console.WriteLine("\n0. Exit");
				string userInput = Console.ReadLine();
				Console.Clear();

				try {
					RunSwitch(userInput);
				} catch (NotImplementedException) { // BEWARE: Can cause debugging issues :')
					Console.WriteLine("You accessed an unfinished section.");
					Console.ReadKey();
				}
			}
		}

		private bool Login() {
			Console.Clear();
			Console.WriteLine("Login:\n");
			Console.Write("Username: "); string Username = GetInput();
			Console.Write("Password: "); SecureString Password = GetPassword();

			try {
				LoggedIn = RepoEmp.Login(Username, Password.ToString());
				Password = null; // Lets take the password out of memory when we're done with it.
				return true;
			} catch (InvalidLoginException) {
				Console.WriteLine("\n\nInvalid User Credentials!");
				Console.ReadKey();
				return false;
			} catch (NoUserException) {
				Console.WriteLine("\n\nNo Users found in System!");
				Console.WriteLine("Please, contact system admin.");
				Console.ReadKey();

				// TODO: Allow registration of first admin, instead of giving this error.
				return false;
			}
		}

		private void RunSwitch(string userInput) {
			CustomerUI CUI = new CustomerUI();
			EmployeeUI EUI = new EmployeeUI();

			switch (userInput) {
				case "1": CUI.ShowCustomers(); break;
				case "2": EUI.ShowEmployees(); break;
				case "3": CUI.UpdateCustomerDatabase(); break;
				case "4": EUI.UpdateEmployeeDatabase(); break;

				case "0": Environment.Exit(0); break;

				default:
					Console.WriteLine("Incorrect Input");
					Console.ReadKey();
				break;
			}
		}

		//private void ShowCustomers()
		//{
		//    UI ui = new UI();
		//    SearchCustomerDatabase searchCustomer = new SearchCustomerDatabase();
		//    Console.WriteLine("Choose Your Option \n" +
		//        "1. Show All Customers \n" +
		//        "0. Back");

		//    string userInput = Console.ReadLine();
		//    Console.Clear();

		//    switch (userInput)
		//    {
		//        case "1":
		//            searchCustomer.ShowAllCustomers();
		//            break;

		//        case "0":
		//            ui.Run();
		//            break;
		//    }
		//}

		//private void ShowEmployees()
		//{
		//    UI ui = new UI();
		//    SearchEmployeeDatabase searchEmployee = new SearchEmployeeDatabase();
		//    Console.WriteLine("Choose Your Option \n" +
		//        "1. Show All Employees \n" +
		//        "0. Back");

		//    string userInput = Console.ReadLine();
		//    Console.Clear();

		//    switch (userInput)
		//    {
		//        case "1":
		//            searchEmployee.ShowAllEmployees();
		//            break;

		//        case "0":
		//            ui.Run();
		//            break;
		//    }
		//}

		//private void WriteLine(string Line) {
		//	int HK = CB.Keys.Last();
		//	CB.Add(HK++, Line + "\n");
		//}

		//private void Write(string Line) {
		//	int HK = CB.Keys.Last();
		//	CB.Add(HK++, Line);
		//}

		//private void WriteConsole(bool clear = true) {
		//	if (clear) Console.Clear();
		//	foreach (var Line in CB) {
		//		Console.Write(Line.Value);
		//	}
		//}

		//private void Clear() {
		//	CB.Clear();
		//}

		internal string GetInput(string validation = "", string err = "") {
			if(err != "") {
				Console.WriteLine(err);
				Console.ReadKey();
			}
			Validator Valid = new Validator();
			string input = Console.ReadLine();
			switch (validation) {
				case "text": // TODO: Make some validation for text only
					if (!Valid.Text(input)) return GetInput(validation, "This field only takes text!");
					break;

				case "email": // TODO: Make Email Validation
					if (!Valid.Email(input)) return GetInput(validation, "Please type valid email!");
					break;


				default: // Lets assume the programmer wants to validate input, if they put a text in the validation field.
					throw new Exception("A validation text was inputted, but no case for it?");

			}

			return input;
		}

		internal SecureString GetPassword() { // Thanks StackOverflow: http://stackoverflow.com/questions/3404421/password-masking-console-application
			var pwd = new SecureString();
			while (true) {
				ConsoleKeyInfo i = Console.ReadKey(true);
				if (i.Key == ConsoleKey.Enter) {
					break;
				} else if (i.Key == ConsoleKey.Backspace) {
					if (pwd.Length > 0) {
						pwd.RemoveAt(pwd.Length - 1);
						Console.Write("\b \b");
					}
				} else {
					pwd.AppendChar(i.KeyChar);
					Console.Write("*");
				}
			}
			return pwd;
		}
	}
}
