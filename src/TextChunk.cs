namespace search_text
{
	public struct TextChunk
	{
		public int ChunkNumber { readonly get; private set; }

		public int LinesCount { readonly get; private set; }

		public int CharsCount { readonly get; private set; }

		public string Text { readonly get; private set; }

		public TextChunk(string text, int chunkNumber, int linesCount)
		{
			Text = text;
			CharsCount = text.Length;
			ChunkNumber = chunkNumber;
			LinesCount = linesCount;
		}
	}
}