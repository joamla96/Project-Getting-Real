using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	class EmployeeRepository {
		Dictionary<int, Employee> Employees = new Dictionary<int, Employee>();

		public Employee Login(string Username, string Password) {
			foreach(KeyValuePair<int, Employee> A in Employees) {
				Employee Emp = A.Value;

				if (Emp.Email == Username
				&&	Emp.Password == Password) {
					return Emp;
				}
			}
			throw new Exception("User Not Found");
		}
	}
}
