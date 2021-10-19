using System;
using System.Collections.Generic;

namespace search_text
{
	class TextSearching
	{
		private int CHUNK_SIZE = 100;

		private FileReader fr;
		private Matcher matcher;

		private IDictionary<string, IList<PhraseMatch>> results = new Dictionary<string, IList<PhraseMatch>>();

		public TextSearching(string fileName, params string[] words)
		{
			Console.WriteLine("Searching: " + fileName);

			matcher = new Matcher(words);

			fr = new FileReader(fileName, CHUNK_SIZE);
		}

		public IDictionary<string, IList<PhraseMatch>> Start()
		{
			int previousCharCount = 0; // In order to fix chunk details, because the "search" works on independent chunks

			TextChunk chunk = fr.GetChunk();

			// Console.WriteLine("Text Chunk: " + " - Chunk: " + chunk.ChunkNumber + " - LinesCount: " + chunk.LinesCount + " - CharsCount: " + chunk.CharsCount);

			while (chunk.Text.Length > 0)
			{
				IList<PhraseMatch> matches = matcher.Search(chunk.Text);

				AddResults(chunk.ChunkNumber, previousCharCount, matches);

				previousCharCount += chunk.CharsCount;

				chunk = fr.GetChunk();

				// Console.WriteLine("\n\nText Chunk: " + " - Chunk: " + chunk.ChunkNumber + " - LinesCount: " + chunk.LinesCount + " - CharsCount: " + chunk.CharsCount);
			}

            return results;
		}

		private void AddResults(int chunk, int previousCharCount, IList<PhraseMatch> matches)
		{
			foreach (PhraseMatch m in matches)
			{
                // Fix values, calculating the chunks
				m.UpdateFields(m.CharOffset + previousCharCount, m.Line + (chunk * CHUNK_SIZE));

                AddOrUpdateResults(m);

				// Console.WriteLine("CharOffset: " + m.CharOffset + " - Line: " + m.Line + " - LineOffset: " + m.LineOffset + " - Word: " + m.Word);
			}
		}

		private void AddOrUpdateResults(PhraseMatch match)
		{
			if (!results.ContainsKey(match.Word))
			{
				results.Add(match.Word, new List<PhraseMatch>());
			}

            results[match.Word].Add(match);
		}
	}
}
