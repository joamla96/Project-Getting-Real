﻿using System;
using System.Collections.Generic;
using Core;
using System.Security;
using Core.CustomExceptions;

namespace Interface {
	internal class Program {
		Dictionary<int, string> CB = new Dictionary<int, string>(); // Console Buffer
		Employee LoggedIn;
		bool ProgramRunning;

		EmployeeRepository RepoEmp = new EmployeeRepository();
		CustomerRepository RepoCus = new CustomerRepository();
		private static void Main() {
			Program myProgram = new Program();
			myProgram.Run();
		}

		internal void Run() {
			ProgramRunning = true;
			while (ProgramRunning) {
				while (LoggedIn == null) {
					Login();
				}
				Console.Clear();
				Console.WriteLine("Schedule Management\nMain Menu");
				Console.WriteLine("Welcome, " + LoggedIn.Firstname + "\n");
				Console.WriteLine("Please Choose Your Option");
				Console.WriteLine("1. Search Customer Database");
				Console.WriteLine("2. Search Employee Database ");
				Console.WriteLine("3. Edit Customer Databasen");
				Console.WriteLine("4. Edit Employee Database");
				Console.WriteLine("5. See Schedule");
				Console.WriteLine("6. Edit Schedule");
				Console.WriteLine("\n0. Exit");
				string userInput = Console.ReadLine();
				Console.Clear();

				try {
					RunSwitch(userInput);
				} //catch (NotImplementedException) { // BEWARE: Can cause debugging issues :')
				//	Console.WriteLine("You accessed an unfinished section.");
				//	Console.ReadKey();
				//}
				catch (Exception e) {  // BEWARE: Can cause debuggin issues :)
					Console.Clear();
					Console.WriteLine("An exception was thrown in the program.");
					Console.WriteLine("Please contact a system administrator.");

					Console.WriteLine("\nException Message:\n" + e.Message);
					Console.WriteLine(e.StackTrace);

					Console.ReadKey();
				}
			}
		}

		private bool Login() {
			Console.Clear();
			Console.WriteLine("Login:\n");
			Console.Write("Username: "); string Username = GetInput();
			Console.Write("Password: "); string Password = GetPassword();

			try {
				LoggedIn = RepoEmp.Login(Username, Password);
				Password = null; // Lets take the password out of memory when we're done with it.
				return true;
			} catch (InvalidLoginException) {
				Console.WriteLine("\n\nInvalid User Credentials!");
				Console.ReadKey();
				return false;
			} catch (NoUserException) {
				EmployeeUI EUI = new EmployeeUI();
				EUI.CreateEmployee();
				return false;
			}
		}

		private void RunSwitch(string userInput) {
			CustomerUI CUI = new CustomerUI();
			EmployeeUI EUI = new EmployeeUI();
			ScheduleUI SUI = new ScheduleUI();

			switch (userInput) {
				case "1": CUI.ShowCustomers(); break;
				case "2": EUI.ShowEmployees(); break;
				case "3": CUI.UpdateCustomerDatabase(); break;
				case "4": EUI.UpdateEmployeeDatabase(); break;
				case "5": throw new NotImplementedException();  break;

				case "0": ProgramRunning = false; break;

				default:
					Console.WriteLine("Incorrect Input");
					Console.ReadKey();
				break;
			}
		}

		internal string GetInput(string validation = "", string err = "") {
			if(err != "") {
				Console.WriteLine(err);
				Console.ReadKey();
			}
			Validator Valid = new Validator();
			string input = Console.ReadLine();
			switch (validation) {
				case "text":
					if (!Valid.Text(input)) return GetInput(validation, "This field only takes text!");
					break;

				case "email":
					if (!Valid.Email(input)) return GetInput(validation, "Please type valid email!");
					break;

				case "number":
					if (!Valid.Number(input)) return GetInput(validation, "Please type a number only!");
					break;

				case "yn":
					if (!Valid.YesNo(input)) return GetInput(validation, "Please type either Yes/y/No/n.");
					break;

				case "phone":
					if (!Valid.Phone(input)) return GetInput(validation, "Please type a valid Phone Number.");
					break;

				default: // Lets assume the programmer wants to validate input, if they put a text in the validation field.
					if(validation != "") throw new Exception("A validation text was inputted, but no case for it?");
					break;
			}

			return input;
		}

		internal string GetPassword() { // Thanks StackOverflow: http://stackoverflow.com/questions/3404421/password-masking-console-application
			string pwd = "";			// Edited to remove securestring because securestring is difficult too difficult to work with.
			while (true) {
				ConsoleKeyInfo i = Console.ReadKey(true);
				if (i.Key == ConsoleKey.Enter) {
					break;
				} else if (i.Key == ConsoleKey.Backspace) {
				if (pwd != "") {
						pwd = pwd.Substring(0, pwd.Length - 1);
						Console.Write("\b \b");
					}
				} else {
					pwd += i.KeyChar;
					Console.Write("*");
				}
			}
			return pwd;
		}

	}
}
