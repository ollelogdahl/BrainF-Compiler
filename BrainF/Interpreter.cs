using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainF {
	internal sealed class Interpreter {
		Lexer lexer = new Lexer();
		static bool hasPrinted = false;

		public void Parse(string expression) {
			var tokens = lexer.Scan(expression);
			Evaluator evaluator = new Evaluator(tokens.ToArray(), KeyboardInput, ConsoleOutput);
			if(hasPrinted) {
				hasPrinted = false;
				Console.WriteLine();
			}
		}



		static byte KeyboardInput() {
			char ch = Console.ReadKey(false).KeyChar;
			return Encoding.ASCII.GetBytes(ch.ToString())[0];
		}

		static void ConsoleOutput(byte ascii) {
			Console.Write(ascii);
			hasPrinted = true;
		}
	}
}
