using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Core {
	public class Database {
		private const string ConnInfo = "Server=ealdb1.eal.local; Database=ejl86_db; User Id=ejl86_usr; Password=Baz1nga86";
		private SqlConnection Conn;

		public void RunSP(string name, Dictionary<string, string> param = null) {	// Run a SP that does not return data (Insert, Delete & Update)
			using (Conn = new SqlConnection(ConnInfo)) {
				SqlCommand cmd = new SqlCommand(name, this.Conn);
				cmd.CommandType = CommandType.StoredProcedure;
				if (param != null) {													// IF paramethers where passed
					foreach (KeyValuePair<string, string> entry in param) {				// Foreach passed parameter
						cmd.Parameters.Add(new SqlParameter(entry.Key, entry.Value));	// add it to the sql cmd.
					}
				}
				try {							
					Conn.Open();                // Open and
					cmd.ExecuteNonQuery();		// execute the command
				} finally {
					Conn.Close();
				}
			}
		}
		public List<Dictionary<string, string>> GetSP(string name, Dictionary<string, string> param = null) {	// Run an SP that does return data (Select)
			using (Conn = new SqlConnection(ConnInfo)) {														// A dictionary in a list? May god have mercy.
				List<Dictionary<string, string>> Result = new List<Dictionary<string, string>>();
				SqlCommand cmd = new SqlCommand(name, this.Conn);
				cmd.CommandType = CommandType.StoredProcedure;
				if (param != null) {													// IF parameters where passed
					foreach (KeyValuePair<string, string> entry in param) {				// Foreach passed parameters
						cmd.Parameters.Add(new SqlParameter(entry.Key, entry.Value));	// add it to the sql cmd.
					}
				}
				Conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				

				if (reader.HasRows) {															// IF Rows where found
					int columns = reader.FieldCount;											// Store how many colums there are

					while (reader.Read()) {                                                     // Okay this is tricky...
						Dictionary<string, string> Row = new Dictionary<string, string>();		// Init. a dictionary, to store single row data
						for (int i = 0; i < reader.FieldCount; i++) {							// For all colums
							Row.Add(reader.GetName(i), reader[i].ToString());					// Add to dictionary in the format of columname, value
						}																		// For example: Add("firstname", "Donato");
						Result.Add(Row);														// Once we're done with a row, add the whole dictionary to the return list
					}
				}
				Conn.Close();
				return Result;
			}
		}
	}
}
