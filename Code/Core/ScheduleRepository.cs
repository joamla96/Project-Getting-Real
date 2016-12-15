using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class ScheduleRepository {
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

			var TskResults = DB.GetSP("usp_GetTasks", Params);
			List<Task> Tasks = new List<Task>();
			foreach (var TskResult in TskResults) {
				Task Tsk = new Task(
					int.Parse(TskResult["ID"]),
					TskResult["Description"]
					);

				Tasks.Add(Tsk);
			}



			var Result = DB.GetSP("usp_GetSchedule", Params);

			RResult = new Schedule(
				int.Parse(Result[0]["ID"]),
				DateTime.Parse(Result[0]["StartDate"]),
				DateTime.Parse(Result[0]["FinishDate"]),
				Tasks,
				RepoCus.GetCustomer(int.Parse(Result[0]["CustomerID"])),
				ScheduleEmps
				);

			return RResult;

		}

		public void SaveSchedule(Schedule Schedule) {
			Dictionary<string, string> Params = new Dictionary<string, string>();
			Params.Add("@StartDate", Schedule.StartDate.ToString("YYYY-MM-DD hh:mm:ss"));
			Params.Add("@FinishDate", Schedule.FinishDate.ToString("YYYY-MM-DDThh:mm:ss"));
			Params.Add("@CustomerID", Schedule.Customer.ID.ToString());

			var ScheduleReturn = DB.GetSP("usp_SaveSchedule", Params);

			int ScheduleID = int.Parse(ScheduleReturn[0]["LastID"]);

			foreach(Task Task in Schedule.Tasks) {
				Params.Clear();
				Params.Add("@ScheduleID", ScheduleID.ToString());
				Params.Add("@Description", Task.Description);

				DB.RunSP("usp_SaveTask", Params);
			}

			foreach(Employee Emp in Schedule.Employees) {
				Params.Clear();
				Params.Add("@ScheduleID", ScheduleID.ToString());
				Params.Add("@EmployeeID", Emp.ID.ToString());

				DB.RunSP("usp_SaveScheduleEmployee", Params);
			}
		}
	}
}
