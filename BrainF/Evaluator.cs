using System;
using System.Collections.Generic;

namespace BrainF {
	internal sealed class Evaluator {
		private readonly Stack<int> callStack = new Stack<int>();

		private readonly Func<byte> input;
		private readonly Action<byte> output;

		private readonly Dictionary<Type, Action> instructionSet = new Dictionary<Type, Action>();
		private readonly byte[] memory = new byte[32768];

		private int dataPointer = 0;
		private int instructionPointer = 0;

		public Evaluator(Token[] tokens, Func<byte> i, Action<byte> o) {
			this.input = i;
			this.output = o;

			CreateInstructions();

			Run(tokens);
		}

		public void CreateInstructions() {
			instructionSet.Add(typeof(AddToken), () => memory[dataPointer]++);
			instructionSet.Add(typeof(SubToken), () => memory[dataPointer]--);
			instructionSet.Add(typeof(IncToken), () => dataPointer++);
			instructionSet.Add(typeof(DecToken), () => dataPointer--);

			instructionSet.Add(typeof(LocToken), () => callStack.Push(instructionPointer));
			instructionSet.Add(typeof(JmpToken), () => {
				var target = callStack.Pop() - 1;
				instructionPointer = memory[dataPointer] != 0 ? target : instructionPointer;
			});

			instructionSet.Add(typeof(OutToken), () => output(memory[dataPointer]));
			instructionSet.Add(typeof(AccToken), () => memory[dataPointer] = input());
		}

		public void Run(Token[] tokens) {
			while(instructionPointer < tokens.Length) {
				// kollar ifall instruktionen har en action, om den har exekvera.
				var instruction = tokens[instructionPointer].GetType();

				Action action;
				if(instructionSet.TryGetValue(instruction, out action)) {
					action();
				}

				instructionPointer++;
			}
		}
	}
}
