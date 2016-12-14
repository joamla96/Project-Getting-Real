using System;
using System.Text.RegularExpressions;

namespace Interface {
	internal class Validator {
		internal bool Text(string input) {
			return Regex.IsMatch(input, @"^[a-zA-Z]+$");
		}

		internal bool Number(string input) {
			return Regex.IsMatch(input, @"^[0-9]+$");
		}

		internal bool Email(string input) { // http://emailregex.com/
											//return Regex.IsMatch(input, @"^[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,64}");
			return true;
		}

		internal bool YesNo(string input) {
			input = input.ToLower();

			if (input == "yes"
			|| input == "no"
			|| input == "y"
			|| input == "n"
			) return true;
			else return false;
		}

		internal bool Phone(string input) { // TODO: Verify this works!
											//return Regex.IsMatch(input, @"(+||00)\d{10}");
			return true;
		}
	}
}
