namespace BrainF {
	abstract class Token {
		public char Symbol		{ get; set; }
		public int LineNumber	{ get; private set; }
		public int CharNumber	{ get; private set; }

		public Token(Source source, char symbol) {
			Symbol = symbol;
			LineNumber = source.LineCounter;
			CharNumber = source.CharCounter;

			source.Read();
		}
	}

	class AddToken : Token { public AddToken(Source source) : base(source, '+') {} }
	class SubToken : Token { public SubToken(Source source) : base(source, '-') {} }
	class OutToken : Token { public OutToken(Source source) : base(source, '.') {} }
	class StrToken : Token { public StrToken(Source source) : base(source, ':') {} }
	class AccToken : Token { public AccToken(Source source) : base(source, ',') {} }

	class IncToken : Token { public IncToken(Source source) : base(source, '>') {} }
	class DecToken : Token { public DecToken(Source source) : base(source, '<') {} }
	class LocToken : Token { public LocToken(Source source) : base(source, '[') {} }
	class JmpToken : Token { public JmpToken(Source source) : base(source, ']') {} }
}
