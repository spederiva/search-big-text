namespace search_text
{
	public struct PhraseMatch
	{
		public string Word { readonly get; private set; }

		public int CharOffset { readonly get; private set; }

		public int Line { readonly get; private set; }

		public int LineOffset { readonly get; private set; }

		public PhraseMatch(string word, int charOffset, int line, int lineOffset)
		{
			Word = word;
			CharOffset = charOffset;
			Line = line;
			LineOffset = lineOffset == 0 ? 1 : lineOffset; // Fix column position
		}

		public void UpdateFields(int charOffset, int line)
		{
			CharOffset = charOffset;
			Line = line;
		}

	}
}