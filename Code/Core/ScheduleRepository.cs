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
			Params.Add("@StartDate", Schedule.StartDate.ToString("yyyy-mm-dd hh:mm:ss"));
			Params.Add("@FinishDate", Schedule.FinishDate.ToString("yyyy-mm-dd hh:mm:ss"));
			Params.Add("@CustomerID", Schedule.Customer.ID.ToString());

			List<Dictionary<string, string>> ScheduleReturn;
			try {
				ScheduleReturn = DB.GetSP("usp_SaveSchedule", Params);
			} catch(Exception e) {
				throw e;
			}

			int ScheduleID = int.Parse(ScheduleReturn[0]["LastID"]);

			foreach(Task Task in Schedule.Tasks) {
				Params.Clear();
				Params.Add("@ScheduleID", ScheduleID.ToString());
				Params.Add("@Description", Task.Description);

				try {
					DB.RunSP("usp_SaveTask", Params);
				} catch (Exception e) {
					throw e;
				}
			}

			foreach(Employee Emp in Schedule.Employees) {
				Params.Clear();
				Params.Add("@ScheduleID", ScheduleID.ToString());
				Params.Add("@EmployeeID", Emp.ID.ToString());

				try {
					DB.RunSP("usp_SaveScheduleEmployee", Params);
				} catch (Exception e) {
					throw e;
				}
			}
		}

		public List<Schedule> GetScheduleEmployee(int employeeID) {
			Dictionary<string, string> Param = new Dictionary<string, string>();
			List<Schedule> Schedules = new List<Schedule>();
			Param.Add("@ID", employeeID.ToString());
			var ScheduleIDs = DB.GetSP("usp_GetEmployeeSchedule", Param);

			foreach(Dictionary<string, string> ScheduleID in ScheduleIDs) {
				Schedules.Add(this.GetSchedule(int.Parse(ScheduleID["ScheduleID"])));
			}

			return Schedules;
		}

		public List<Schedule> GetScheduleEmployee(int employeeID, DateTime FromDate, DateTime ToDate) {
			Dictionary<string, string> Param = new Dictionary<string, string>();
			List<Schedule> Schedules = new List<Schedule>();
			Param.Add("@ID", employeeID.ToString());
			Param.Add("@StartDate", FromDate.ToString("yyyy-mm-dd hh:mm:ss"));
			Param.Add("@FinishDate", ToDate.ToString("yyyy-mm-dd hh:mm:ss"));
			var ScheduleIDs = DB.GetSP("usp_GetEmployeeScheduleWithDate", Param);

			foreach (Dictionary<string, string> ScheduleID in ScheduleIDs) {
				Schedules.Add(this.GetSchedule(int.Parse(ScheduleID["ScheduleID"])));
			}

			return Schedules;
		}
	}
}
