using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class Task {
		public int ID { get; set; }
		public string Description { get; set; }

		public Task(int id, string description) {
			this.ID = id;
			this.Description = description;
		}
	}
}
