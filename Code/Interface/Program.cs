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
                Console.WriteLine("Please Choose Your Option\n" +
                    "1. Search Customer Database \n" +
                    "2. Search Employee Database \n" +
                    "3. Edit Customer Database \n" +
                    "4. Edit Employee Database \n" +
                    "0. Exit");
                string userInput = Console.ReadLine();
                Console.Clear();

            }
        }

        private static void RunSwitch(string userInput)
        {
            Program ui = new Program();

            switch (userInput)
            {
                case "1":
                    //ui.ShowCustomers();
                    break;

                case "2":
                    //ui.ShowEmployees();
                    break;
                case "3":
                    ui.UpdateCustomerDatabase();
                    break;

                case "4":
                    ui.UpdateCustomerDatabase();
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
            Program ui = new Program();
            Database edit = new Database();
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
                    //edit.CreateCustomer();
                    break;

                case "2":
                    //edit.UpdateCustomer();
                    break;

                case "3":
                    //edit.DeleteCustomer();
                    break;

                case "0":
                    ui.Run();
                    break;
            }
        }

        private void UpdateEmployeeDatabase()
        {
            Program ui = new Program();
            Database edit = new Database();
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
                    //edit.CreateEmployee();
                    break;

                case "2":
                    //edit.UpdateEmployee();
                    break;

                case "3":
                    //edit.DeleteEmployee();
                    break;

                case "0":
                    ui.Run();
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
