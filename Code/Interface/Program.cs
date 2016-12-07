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

				RunSwitch(userInput);
            }
        }

        private void RunSwitch(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    //ShowCustomers();
                    break;

                case "2":
                    //ShowEmployees();
                    break;
                case "3":
                   UpdateCustomerDatabase();
                  break;

                case "4":
                    UpdateCustomerDatabase();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Incorrect Input");
                    break;
            }
        }

        private void UpdateCustomerDatabase()
        {
            Console.WriteLine("Choose Your Updated Options\n" +
                "1. Create Customer \n" +
                "2. Update Customer \n" +
                "3. Delete Customer \n" +
                "0. Back");

            string userInput = Console.ReadLine();
            Console.Clear();

            switch (userInput)
            {
                case "1":
                    //CreateCustomer();
                    break;

                case "2":
                    //UpdateCustomer();
                    break;

                case "3":
                    //DeleteCustomer();
                    break;

                case "0":
					return;
            }
        }

        private void UpdateEmployeeDatabase()
        {
            Console.WriteLine("Choose Your Updated Options\n" +
                "1. Create Employee \n" +
                "2. Update Employee \n" +
                "3. Delete Employee \n" +
                "0. Back");

            string userInput = Console.ReadLine();
            Console.Clear();

            switch (userInput)
            {
                case "1":
                    //CreateEmployee();
                    break;

                case "2":
                    //UpdateEmployee();
                    break;

                case "3":
                    //DeleteEmployee();
                    break;

                case "0":
					return;
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
