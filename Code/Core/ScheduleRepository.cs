using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	class ScheduleRepository {
		private Dictionary<int, Schedule> Schedules = new Dictionary<int, Schedule>();
		private Database DB = new Database();
		private EmployeeRepository RepoEmp = new EmployeeRepository();
		private CustomerRepository RepoCus = new CustomerRepository();

		public Schedule GetSchedule(int ID) {
			Dictionary<string, string> Params = new Dictionary<string, string>();
			List<Employee> ScheduleEmps = null;
			Schedule RResult;
			Params.Add("@ID", ID.ToString());
			var EmpResults = DB.GetSP("usp_GetScheduleEmployees", Params);

			foreach(var EmpResult in EmpResults) {
				ScheduleEmps.Add(RepoEmp.GetEmployee(int.Parse(EmpResult["EmployeeID"])));
			}



			var Result = DB.GetSP("usp_GetSchedule", Params);

			RResult = new Schedule(
				Result[0]["ID"],
				DateTime.Parse(Result[0]["StartDate"]),
				DateTime.Parse(Result[0]["FinishDate"]),
				// Tasks go here
				RepoCus.GetCustomer(int.Parse(Result[0]["CustomerID"])),
				ScheduleEmps
				);

			return RResult;

		}

		public void SaveSchedule(Schedule Schedule) {

		}
	}
}
