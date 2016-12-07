using System;
using System.Collections.Generic;

namespace Core
{
    public class CustomerRepository
    {
        private Dictionary<int, Customer> Customers = new Dictionary<int, Customer>();
        private Database DB = new Database();

		public Customer GetCustomer(int id) {
			Dictionary<string, string> Params = new Dictionary<string, string>();
			Customer RResult = null;
			Params.Add("@ID", id.ToString());
			var Result = DB.GetSP("usp_GetCustomer", Params);

			foreach (var Row in Result) {
					foreach (KeyValuePair<string, string> kvp in Row) {
						//textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
						Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
					}
				Address Addr = new Address(
					int.Parse(Row["HouseNo"]),
					int.Parse(Row["FloorNo"]),
					Row["Entrance"],
					Row["Streetname"],
					int.Parse(Row["PostCode"]),
					Row["City"]
				);

				RResult = new Customer(
					int.Parse(Row["ID"]),
					Row["Email"],
					Row["Firstname"],
					Row["Lastname"],
					Addr,
					Row["Phone"]
				);
			}

			return RResult;

		}
		public List<Customer> GetCustomers()
        {
			// Convert Dictrionary to List (without having any KeyValuePairs)s
			//List<Customer> CustomerList = new List<Customer>();
			//CustomerList.AddRange(Customers.Values);
			//return CustomerList;

			List<Customer> CustomerList = new List<Customer>();

			var Result = DB.GetSP("usp_GetALLCustomer");

			foreach(var Row in Result) {
				Address Addr = new Address(
					int.Parse(Row["HouseNo"]),
					int.Parse(Row["FloorNo"]),
					Row["Entrance"],
					Row["Streetname"],
					int.Parse(Row["PostCode"]),
					Row["City"]
				);
				Customer C = new Customer(
					int.Parse(Row["ID"]),
					Row["Email"],
					Row["Firstname"],
					Row["Lastname"],
					Addr,
					Row["Phone"]
				);

				CustomerList.Add(C);
			}

			return CustomerList;
		}

		public int NextID() { // Get the next available ID.
			throw new NotImplementedException();
		}

		public void SaveCustomer(Customer Customer)
        {
            //this.Delete(Customer.ID);
            //this.Customers.Add(Customer.ID, Customer);
            Dictionary<string, string> param = new Dictionary<string, string>();
            Address addr = Customer.Address;
            param.Add("@Firstname", Customer.Firstname);
            param.Add("@Lastname", Customer.Lastname);
            param.Add("@Email", Customer.Email);
            param.Add("@Phone", Customer.Phone);
            param.Add("@HouseNo", addr.HouseNo.ToString());
            param.Add("@FloorNo", "" + addr.FloorNo.ToString());
            param.Add("@Streetname", addr.Streetname);
            param.Add("@Entrance", "" + addr.Entrance);
            param.Add("@City", addr.City);
            param.Add("@PostCode", addr.PostCode.ToString());

            DB.RunSP("usp_SaveCustomer", param);

        }

        public void Update(int id, string prop, string newvalue)
        {
			Dictionary<string, string> Param = new Dictionary<string, string>();
			Param.Add("@ID", id.ToString());
			switch (prop) {
				case "Firstname": Param.Add("@Firstname", newvalue); break;
				case "Lastname": Param.Add("@Lastname", newvalue); break;
				case "Email": Param.Add("@Email", newvalue); break;
				case "Phone": Param.Add("@Phone", newvalue); break;
				default: throw new Exception("Invalid Property");
			}

			DB.RunSP("UpdateCustomer", Param);
		}

		public void Update(int id, string prop, Address newvalue)
        {
            if (prop != "Address") throw new Exception("Invalid Property");
			Dictionary<string, string> Params = new Dictionary<string, string>();
			Params.Add("@ID", id.ToString());

			Params.Add("@HouseNo", newvalue.HouseNo.ToString());
			Params.Add("@FloorNo", newvalue.FloorNo.ToString());
			Params.Add("@Entrance", newvalue.Entrance);
			Params.Add("@Streetname", newvalue.Streetname);
			Params.Add("@City", newvalue.City);
			Params.Add("@PostCode", newvalue.PostCode.ToString());

			DB.RunSP("UpdateCustomer", Params);
        }

        public bool Delete(int id)
        {
			Dictionary<string, string> input = new Dictionary<string, string>();
			input.Add("@ID", id.ToString());
            DB.RunSP("DeleteCustomer", input);
			return true;

                //Customers.Remove(id);
				
                
        }
    }

}
