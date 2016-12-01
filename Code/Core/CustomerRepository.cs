using System;
using System.Collections.Generic;

namespace Core
{
    public class CustomerRepository
    {
        private Dictionary<int, Customer> Customers = new Dictionary<int, Customer>();
        private Database DB = new Database();
        public List<Customer> GetCustomers()
        {
            // Convert Dictrionary to List (without having any KeyValuePairs)s
            List<Customer> CustomerList = new List<Customer>();
            CustomerList.AddRange(Customers.Values);

            return CustomerList;
        }
        public Customer GetCustomer(int ID)
        {
            return Customers[ID];
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
            param.Add("@FloorNo", addr.FloorNo.ToString());
            param.Add("@Streetname", addr.Streetname);
            param.Add("@Entrance", "" + addr.Entrance);
            param.Add("@City", addr.City);
            param.Add("@PostCode", addr.PostCode.ToString());

            DB.RunSP("usp_SaveCustomer", param);

        }

        public void Update(int id, string prop, string newvalue)
        {
            Customer Customer = this.GetCustomer(id);

            switch (prop)
            {
                case "Firstname": Customer.Firstname = newvalue; break;
                case "Lastname": Customer.Lastname = newvalue; break;
                case "Email": Customer.Email = newvalue; break;
                case "password": Customer.Password = newvalue; break;
                case "Phone": Customer.Phone = newvalue; break;
                default: throw new Exception("Invalid Property");
            }

            this.SaveCustomer(Customer);
        }

        public void Update(int id, string prop, Address newvalue)
        {
            if (prop != "Address") throw new Exception("Invalid Property");
            Customer Customer = this.GetCustomer(id);
            Customer.Address = newvalue;

            this.SaveCustomer(Customer);
        }

        public bool Delete(int id)
        {
            if (Customers.ContainsKey(id))
            {
                Customers.Remove(id);
                return true;
            }
            else { return false; }
        }
    }

}
