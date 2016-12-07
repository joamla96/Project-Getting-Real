using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Interface {
	internal class Program {
        private static void Main()
        {
            Program myProgram = new Program();
            myProgram.Run();
        }

        public void Run()
        {
            while (true)
            {
				Console.Clear();
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
				} catch(NotImplementedException) {
					Console.WriteLine("You accessed an unfinished section.");
					Console.ReadKey();
				}
            }
        }

        private void RunSwitch(string userInput)
        {
			CustomerUI CUI = new CustomerUI();
			EmployeeUI EUI = new EmployeeUI();

            switch (userInput)
            {
                case "1":
                    CUI.ShowCustomers();
                    break;

                case "2":
                    EUI.ShowEmployees();
                    break;
                case "3":
                   CUI.UpdateCustomerDatabase();
                  break;

                case "4":
                    EUI.UpdateEmployeeDatabase();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Incorrect Input");
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
    }
}
