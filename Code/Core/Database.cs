using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Core {
	public class Database {
		private const string ConnInfo = "Server=ealdb1.eal.local; Database=ejl86_db; User Id=ejl86_usr; Password=Baz1nga86";
		private SqlConnection Conn;

		//Database()
		//{
		//    Conn = new SqlConnection(ConnInfo);
		//}

		public void RunSP(string name, Dictionary<string, string> param = null) {
			using (Conn = new SqlConnection(ConnInfo)) {
				SqlCommand cmd = new SqlCommand(name, this.Conn);
				cmd.CommandType = CommandType.StoredProcedure;
				if (param != null) {
					foreach (KeyValuePair<string, string> entry in param) {
						cmd.Parameters.Add(new SqlParameter(entry.Key, entry.Value));
					}
				}
				try {
					Conn.Open();
					cmd.ExecuteNonQuery();
				} finally {
					Conn.Close();
				}
			}
		}
		public List<Dictionary<string, string>> GetSP(string name, Dictionary<string, string> param = null) {
			using (Conn = new SqlConnection(ConnInfo)) {
				List<Dictionary<string, string>> Result = new List<Dictionary<string, string>>();
				SqlCommand cmd = new SqlCommand(name, this.Conn);
				cmd.CommandType = CommandType.StoredProcedure;
				if (param != null) {
					foreach (KeyValuePair<string, string> entry in param) {
						cmd.Parameters.Add(new SqlParameter(entry.Key, entry.Value));
					}
				}
				Conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				

				if (reader.HasRows) {
					int columns = reader.FieldCount;

					while (reader.Read()) {
						Dictionary<string, string> Row = new Dictionary<string, string>();
						for (int i = 0; i < reader.FieldCount; i++) {
							Row.Add(reader.GetName(i), reader[i].ToString());
						}
						Result.Add(Row);
					}
				}
				Conn.Close();
				return Result;
			}

		}
	}
}
