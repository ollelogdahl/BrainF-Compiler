using System;
using System.Collections.Generic;

namespace BrainF {
	internal sealed class Lexer {
		private Source source;

		public IEnumerable<Token> Scan(string expression) {
			source = new Source(expression);

			var tokens = new List<Token>();
			while (source.HasNext()) {
				// skannar en token ( 1 tecken )
				Token t = ScanToken();
				if(t != null) tokens.Add(t);
			}

			return tokens;
		}

		// returnerar en token för vårat nuvarande tecken,
		// läser hela ifall det är en ident / siffra.
		private Token ScanToken() {
			char c = source.Peek();
			switch (c) {
				case '+': return new AddToken(source);
				case '-': return new SubToken(source);
				case '.': return new OutToken(source);
				case ':': return new StrToken(source);
				case ',': return new AccToken(source);

				case '>': return new IncToken(source);
				case '<': return new DecToken(source);
				case '[': return new LocToken(source);
				case ']': return new JmpToken(source);
			}

			source.Read();
			return null;
		}
	}
}
