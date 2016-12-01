using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Core
{
    public class Database
    {
        private const string ConnInfo = "Server=ealdb1.eal.local; Database=ejl86_usr; Password=Baz1nga86";
        private SqlConnection Conn;

        //Database()
        //{
        //    Conn = new SqlConnection(ConnInfo);
        //}

        public void RunSP(string name, Dictionary<string,string> param)
        {
            using (Conn = new SqlConnection(ConnInfo))
            {
                SqlCommand cmd = new SqlCommand(name, this.Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach(KeyValuePair<string,string> entry in param)
                {
                    cmd.Parameters.Add(new SqlParameter(entry.Key, entry.Value));
                }
                try
                {
                    Conn.Open();
                    cmd.ExecuteNonQuery();
                }

                finally
                {
                    Conn.Close();
                }
            }                
        }
    }
}
