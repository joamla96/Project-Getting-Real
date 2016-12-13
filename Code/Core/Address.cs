namespace Core {
	public class Address {
		public int HouseNo { get; set; }
		public int FloorNo { get; set; }
		public string Entrance { get; set; } // Eg. Left / Right
		public string Streetname { get; set; }
		public string City { get; set; }
		public int PostCode { get; set; }

		public Address(int housenr, int floornr, string enterance, string streetname, int postalcode, string city) {
			this.HouseNo = housenr;
			this.FloorNo = floornr;
			this.Entrance = enterance;
			this.Streetname = streetname;
			this.City = city;
			this.PostCode = postalcode;
		}

		public Address(int housenr, string streetname, int postalcode, string city) {
			this.HouseNo = housenr;
			this.Streetname = streetname;
			this.City = city;
			this.PostCode = postalcode;
		}

		public override string ToString() {
			string output = "HouseNo: " + this.HouseNo + "\n" +
				"FloorNo: " + this.FloorNo + "\n" +
				"Entrance: " + this.Entrance + "\n" +
				"Streetname: " + this.Streetname + "\n" +
				"City: " + this.City + "\n" +
				"PostCode: " + this.PostCode;

			return output;
		}
	}
}
