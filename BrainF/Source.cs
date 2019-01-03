using System.IO;
namespace BrainF {
	class Source {
		public string Path { get; private set; }
		public int LineCounter { get; private set; }
		public int CharCounter { get; private set; }

		private StringReader reader;

		public Source(string path) {
			Path = path;
			LineCounter = 0;
			CharCounter = 0;

			reader = new StringReader(Path);
		}

		public bool HasNext() {
			return reader.Peek() != -1;
		}

		public void Read() {
			char c = (char)reader.Read();

			if (c == '\n') {
				LineCounter++;
				CharCounter = 0;
			} else CharCounter++;
		}

		public char Peek() {
			return (char)reader.Peek();
		}
	}
}
