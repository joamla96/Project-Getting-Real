using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class Address {
		public int HouseNr { get; set; }
		public int FloorNr { get; set; }
		public string Enterance { get; set; } // Eg. Left / Right
		public string Streetname { get; set; }
		public string City { get; set; }
		public int PostalCode { get; set; }
	}
}
