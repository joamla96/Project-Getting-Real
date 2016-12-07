using Core.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Security;

namespace Core {
	public class EmployeeRepository {
		private Dictionary<int, Employee> Employees = new Dictionary<int, Employee>();

		public Employee Login(string Username, string Password) {
			foreach(Employee Emp in GetEmployees()) {
				if (Emp.Email == Username
				&&	Emp.Password == Password) {
					return Emp;
				}
			}
			throw new NoUserException();
		}

		public List<Employee> GetEmployees() {
			// Convert Dictrionary to List (without having any KeyValuePairs)s
			List<Employee> EmpList = new List<Employee>();
			EmpList.AddRange(Employees.Values);

			return EmpList;
		}
		public Employee GetEmployee(int ID) {
			return Employees[ID];
		}

		public void SaveEmployee(Employee Emp) {
			this.Delete(Emp.ID);
			this.Employees.Add(Emp.ID, Emp);
		}

		public void Update(int id, string prop, string newvalue) {
			Employee Emp = this.GetEmployee(id);

			switch(prop) {
				case "Firstname": Emp.Firstname = newvalue; break;
				case "Lastname": Emp.Lastname = newvalue; break;
				case "Email": Emp.Email = newvalue; break;
				case "password": Emp.Password = newvalue; break;
				case "Phone": Emp.Phone = newvalue; break;
				default: throw new Exception("Invalid Property");
			}

			this.SaveEmployee(Emp);
		}
		
		public void Update(int id, string prop, Address newvalue) {
			if (prop != "Address") throw new Exception("Invalid Property");
			Employee Emp = this.GetEmployee(id);
			Emp.Address = newvalue;

			this.SaveEmployee(Emp);
		}

		public bool Delete(int id) {
			if (Employees.ContainsKey(id)) {
				Employees.Remove(id);
				return true;
			} else { return false; }
		}
	}
}
