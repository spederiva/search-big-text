using System;
using System.Collections.Generic;

namespace search_text
{
	class TextSearching
	{
		private int CHUNK_SIZE = 10;

		FileReader fr;
		Matcher matcher;

		public TextSearching(string fileName)
		{
			Console.WriteLine("Searching: " + fileName);

			matcher = new Matcher("sebastian", "Shir", "Paul", "Boone", "Autism", "Michael", "William", "Richard");

			fr = new FileReader(fileName, CHUNK_SIZE);
		}

		public void start()
		{
            int previousCharCount = 0; // In order to fix chunk details, because the search is done by isolated chunks

			TextChunk chunk = fr.GetChunk();
            previousCharCount = chunk.CharsCount;

			Console.WriteLine("Text Chunk: " + " - Chunk: " + chunk.ChunkNumber + " - LinesCount: " + chunk.LinesCount + " - CharsCount: " + chunk.CharsCount);

			while (chunk.Text.Length > 0)
			{
				IList<PhraseMatch> matches = matcher.Search(chunk.Text);

				fixPhraseMatchDetails(chunk.ChunkNumber, previousCharCount, matches);

				chunk = fr.GetChunk();

				Console.WriteLine("\n\nText Chunk: " + " - Chunk: " + chunk.ChunkNumber + " - LinesCount: " + chunk.LinesCount + " - CharsCount: " + chunk.CharsCount);
			}
		}

		private void fixPhraseMatchDetails(int chunk, int previousCharCount, IList<PhraseMatch> matches)
		{
			foreach (PhraseMatch m in matches)
			{
				m.UpdateFields(m.CharOffset + previousCharCount, m.Line + (chunk * CHUNK_SIZE));

				Console.WriteLine("CharOffset: " + m.CharOffset + " - Line: " + m.Line + " - LineOffset: " + m.LineOffset + " - Word: " + m.Word);
			}
		}
	}
}
