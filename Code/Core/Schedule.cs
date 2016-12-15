using System;
using System.Collections.Generic;
using System.IO;

namespace Core {
	public class Schedule {
		public int ID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime FinishDate { get; set; }
		public List<Task> Tasks { get; set; }
		public Customer Customer { get; set; }
		public List<Employee> Employees { get; set; }

		public Schedule(int id, DateTime startDate, DateTime finishDate, List<Task> tasks, Customer customer, List<Employee> employees) {
			this.ID = id;
			this.StartDate = startDate;
			this.FinishDate = finishDate;
			this.Tasks = tasks;
			this.Customer = customer;
			this.Employees = employees;
		}

		public Schedule(DateTime startDate, DateTime finishDate, List<Task> tasks, Customer customer, List<Employee> employees) {
			this.StartDate = startDate;
			this.FinishDate = finishDate;
			this.Tasks = tasks;
			this.Customer = customer;
			this.Employees = employees;
		}

		public override string ToString() {
			StringWriter SW = new StringWriter();

			SW.WriteLine("Schedule ID: " + this.ID);
			SW.WriteLine("Customer: " + this.Customer.ToString());
			SW.WriteLine("Start Date: " + this.StartDate.ToString("dd/mm/yyy hh:mm"));
			SW.WriteLine("Finish Date: " + this.FinishDate.ToString("dd/mm/yyy hh:mm"));

			SW.WriteLine("Tasks:");
			foreach(Task Task in this.Tasks) {
				SW.WriteLine(" - " + Task.ToString());
			}

			SW.WriteLine("Employees:");
			foreach(Employee Emp in this.Employees) {
				SW.WriteLine(" - " + Emp.Firstname + " " + Emp.Lastname);
			}

			return SW.ToString();
		}
	}
}
