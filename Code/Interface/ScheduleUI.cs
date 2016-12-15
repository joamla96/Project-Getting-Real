using System;
using System.Collections.Generic;
using Core;

namespace Interface {
	public class ScheduleUI {
		Program Program = new Program();
		CustomerUI CUI = new CustomerUI();
		EmployeeUI EUI = new EmployeeUI();

		EmployeeRepository RepoEmp = new EmployeeRepository();
		CustomerRepository RepoCus = new CustomerRepository();
		ScheduleRepository RepoSch = new ScheduleRepository();

		internal void ScheduleMenu() {
			bool InMenu = true;
			while (InMenu) {
				Console.WriteLine("1. Create new Schedule");
				Console.WriteLine("2. Update Scedule");
				Console.WriteLine("3. Delete Schedule");

				switch(Program.GetInput("number")) {
					case "1": CreateNewSchedule(); break;
					case "2": UpdateSchedule(); break;
					case "3": DeleteSchedule(); break;
				}
			}


		}

		private void DeleteSchedule() {
			throw new NotImplementedException();
		}

		private void UpdateSchedule() {
			throw new NotImplementedException();
		}

		private void CreateNewSchedule() {
			Console.Clear();
			CUI.ShowCustomers();

			Console.WriteLine("ID of Customer:");
			Customer Customer = RepoCus.GetCustomer(int.Parse(Program.GetInput("number")));

			Console.Clear();
			Console.WriteLine("When does this schedule start? (dd/mm/yyyy hh:mm)");
			DateTime StartDate = DateTime.Parse(Program.GetInput("date"));

			Console.WriteLine("\nWhen does this shcedule end? (dd/mm/yyyy hh:mm)");
			DateTime FinishDate = DateTime.Parse(Program.GetInput("date"));

			List<Task> Tasks = GetTasks();
			List<Employee> Employees = GetEmployees();

			Schedule Schedule = new Schedule(StartDate, FinishDate, Tasks, Customer, Employees);
			RepoSch.SaveSchedule(Schedule);
		}

		private List<Task> GetTasks() {
			List<Task> Tasks = new List<Task>();
			bool MoreTasks = true;

			while(MoreTasks) {
				Console.Clear();
				Console.WriteLine("Write description of Task: (Write \"quit\", \"q\" or \"0\" to exit)");

				string Input = Program.GetInput();
				if (Input.ToLower() == "quit" || Input.ToLower() == "q" || Input == "0") {
					MoreTasks = false;
				} else {
					Task Task = new Task(Input);
					Tasks.Add(Task);
				}
			}

			return Tasks;
		}

		private List<Employee> GetEmployees() {
			List<Employee> Employees = new List<Employee>();
			bool MoreEmployees = true;

			while(MoreEmployees) {
				Console.Clear();
				EUI.ShowEmployees();

				Console.WriteLine("Write ID of Employee to add to Schedule: (Write \"0\" to exit)");
				string Input = Program.GetInput("number");

				if(Input == "0") {
					MoreEmployees = false;
				} else {
					Employees.Add(RepoEmp.GetEmployee(int.Parse(Input)));
				}
			}

			return Employees;
		}

		internal void SeeSchedule() {
			throw new NotImplementedException();
		}
	}
}
