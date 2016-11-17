using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class EmployeeRepository {
		private Dictionary<int, Employee> Employees = new Dictionary<int, Employee>();

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

		public List<Employee> GetEmployees() {
			// Convert Dictrionary to List (without having any KeyValuePairs)s
			List<Employee> EmpList = new List<Employee>();
			EmpList.AddRange(Employees.Values);

			return EmpList;
		}

		public void SaveEmployee(Employee Emp) {
			if (this.Employees.ContainsKey(Emp.ID)) {
				this.Employees.Remove(Emp.ID);
			}

			this.Employees.Add(Emp.ID, Emp);
		}
	}
}
