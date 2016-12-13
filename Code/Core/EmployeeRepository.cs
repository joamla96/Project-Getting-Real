using Core.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace Core {
	public class EmployeeRepository {
		private Dictionary<int, Employee> Employees = new Dictionary<int, Employee>();
        Database DB = new Database();

		public Employee Login(string Username, string Password) {
			var Employees = GetEmployees();

			if(!Employees.Any()) {
				throw new NoUserException();
			}

			foreach(Employee Emp in GetEmployees()) {
				if (Emp.Email == Username
				&&	Emp.Password == Password) {
					return Emp;
				}
			}
			throw new InvalidLoginException();
		}

		public List<Employee> GetEmployees() {
            List<Employee> EmployeeList = new List<Employee>();

            var Result = DB.GetSP("usp_GetALLEmployees");
			
            foreach (var Row in Result)
            {
				Address Addr = new Address(
					int.Parse(Row["HouseNo"].ToString()),
                    int.Parse(Row["FloorNo"].ToString()),
                    Row["Entrance"],
                    Row["Streetname"],
                    int.Parse(Row["PostCode"].ToString()),
                    Row["City"]
                );
                Employee C = new Employee(
                    int.Parse(Row["ID"]),
                    Row["Email"],
                    Row["Password"],
                    Row["Firstname"],
                    Row["Lastname"],
                    Addr,
                    Row["Phone"],
                    int.Parse(Row["Permission"].ToString())
                );

                EmployeeList.Add(C);
            }

            return EmployeeList;
        }
		public Employee GetEmployee(int ID) {
            Dictionary<string, string> Params = new Dictionary<string, string>();
            Employee RResult = null;
            Params.Add("@ID", ID.ToString());
            var Result = DB.GetSP("usp_GetEmployee", Params);

            foreach (var Row in Result)
            {
                Address Addr = new Address(
                    int.Parse(Row["HouseNo"]),
                    int.Parse(Row["FloorNo"]),
                    Row["Entrance"],
                    Row["Streetname"],
                    int.Parse(Row["PostCode"]),
                    Row["City"]
                );

                RResult = new Employee(
                    int.Parse(Row["ID"]),
                    Row["Email"],
                    Row["Password"],
                    Row["Firstname"],
                    Row["Lastname"],
                    Addr,
                    Row["Phone"],
                    int.Parse(Row["Permission"])

                );
            }

            return RResult;
        }

		public void SaveEmployee(Employee Emp) {
            Dictionary<string, string> param = new Dictionary<string, string>();
            Address addr = Emp.Address;
            param.Add("@Firstname", Emp.Firstname);
            param.Add("@Lastname", Emp.Lastname);
            param.Add("@Email", Emp.Email);
            param.Add("@Password", Emp.Password);
            param.Add("@Phone", Emp.Phone);
            param.Add("@Permission", Emp.Permissions.ToString());
            param.Add("@HouseNo", addr.HouseNo.ToString());
            param.Add("@FloorNo", "" + addr.FloorNo.ToString());
            param.Add("@Streetname", addr.Streetname);
            param.Add("@Entrance", "" + addr.Entrance);
            param.Add("@City", addr.City);
            param.Add("@PostCode", addr.PostCode.ToString());
            

            DB.RunSP("usp_SaveEmployee", param);
        }

		public void Update(int id, string prop, string newvalue) {
            Dictionary<string, string> Param = new Dictionary<string, string>();
            Param.Add("@ID", id.ToString());
            switch (prop)
            {
                case "Firstname": Param.Add("@Firstname", newvalue); break;
                case "Lastname": Param.Add("@Lastname", newvalue); break;
                case "Email": Param.Add("@Email", newvalue); break;
				case "Password": Param.Add("@Password", newvalue); break; //@L
                case "Phone": Param.Add("@Phone", newvalue); break;
                case "Permission": Param.Add("@Permission", newvalue); break;
                default: throw new Exception("Invalid Property");
            }

            DB.RunSP("UpdateEmployee", Param);
        }
		
		public void Update(int id, string prop, Address newvalue) {
            if (prop != "Address") throw new Exception("Invalid Property");
            Dictionary<string, string> Params = new Dictionary<string, string>();
            Params.Add("@ID", id.ToString());

            Params.Add("@HouseNo", newvalue.HouseNo.ToString());
            Params.Add("@FloorNo", newvalue.FloorNo.ToString());
            Params.Add("@Entrance", newvalue.Entrance);
            Params.Add("@Streetname", newvalue.Streetname);
            Params.Add("@City", newvalue.City);
            Params.Add("@PostCode", newvalue.PostCode.ToString());

            DB.RunSP("UpdateEmployee", Params);
        }

		public bool Delete(int id) {
            Dictionary<string, string> input = new Dictionary<string, string>();
            input.Add("@ID", id.ToString());
            DB.RunSP("DeleteEmployee", input);
            return true;
        }
	}
}
