﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	enum Permissions {
		Manager = 1,
		Employee = 2
	};
	public class Employee {
		public int ID { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public Address Address { get; set; }
		public string Phone { get; set; }
		public Enum Permissions { get; set; }

		public Employee(int id, string email, string password, string firstname, string lastname, Address address, string phone) {
			this.ID = id;
			this.Email = email;
			this.Password = password;
			this.Firstname = firstname;
			this.Lastname = lastname;
			this.Address = address;
			this.Phone = phone;
		}
	}
}
