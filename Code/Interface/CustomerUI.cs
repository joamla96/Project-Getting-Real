using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface {
	internal class CustomerUI {
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

		internal void ShowCustomers() {
			throw new NotImplementedException();
		}
	}
}
