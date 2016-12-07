using System.Collections.Generic;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Core {
	[TestClass]
	public class DatabaseTests {

		[TestMethod]
		public void TestCheckDatabaseGetSP() {
			Database DB = new Database();

			var Result = DB.GetSP("usp_GetALLCustomer");

			foreach (Dictionary<string, string> Row in Result) {
				foreach (KeyValuePair<string, string> kvp in Row) {
					//textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
					Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
				}
				Console.WriteLine("----------------");
			}

			Assert.IsTrue(true);
		}
	}
}
