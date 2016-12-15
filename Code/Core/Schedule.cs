using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
