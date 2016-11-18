using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface {
	class Program {
		Dictionary<int, string> CB = new Dictionary<int, string>();
		static void Main(string[] args) {
			Program A = new Program();
			A.Run();
		}
	
		private void WriteLine(string Line) {
			int HK = CB.Keys.Last();
			CB.Add(HK++, Line);
		}

		private void WriteConsole(bool clear = true) {
			if(clear) Console.Clear();
			foreach(var Line in CB) {
				Console.WriteLine(Line.Value);
			}
		}

		private void Clear() {
			CB.Clear();
		}

		private void Run() {
			WriteLine("TEST");
			WriteLine("TEST2");
			WriteLine("Test3");
			WriteConsole(false);
		}
	}
}
