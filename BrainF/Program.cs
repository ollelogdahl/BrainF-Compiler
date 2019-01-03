using System;
using System.IO;
namespace BrainF {
	class Program {
		static void Main(string[] args) {
			Interpreter interpreter = new Interpreter();

			Console.WriteLine("- BrainF Compiler -");
			if (args.Length == 0) {
				// kör interpreter, där man får mata in själv
				string code = "";
				while (true) {
					Console.Write(": ");
					code += Console.ReadLine();

					interpreter.Parse(code);
				}
			}

			string fileLocation = "";
			for(int i = 0; i < args.Length; i++) {
				if(args[i] == "-r") {
					fileLocation = args[i + 1];
				}
				if(args[i] == "-h") {
					Console.WriteLine();
					Console.WriteLine("usage:");
					Console.WriteLine("-r	<path> : Interpret and run");
					return;
				}
			}

			if (fileLocation != "") {
				Console.WriteLine($"Parsing {fileLocation}...");
				Console.WriteLine("Program Output:");
				StreamReader reader = new StreamReader(fileLocation);
				string code = reader.ReadToEnd();

				interpreter.Parse(code);
			} else Console.WriteLine("Need source code to execute.");
		}
	}



	/*
	string program = @"
		++
		> +++++
		[
			< +
			> -
		]
		< .
	";
	*/
}
