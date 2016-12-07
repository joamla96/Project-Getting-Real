namespace Core {
	public class Customer
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }

        public Customer(int id, string email, string firstname, string lastname, Address address, string phone)
        {
            this.ID = id;
            this.Email = email;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Address = address;
            this.Phone = phone;
        }
    }
}