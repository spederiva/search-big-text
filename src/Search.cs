using System;
using System.Collections.Generic;

namespace search_text
{
	class TextSearching
	{
		private const int MIN_CHUNK_SIZE = 10;

		private int CHUNK_SIZE = 1000;

		private FileReader fr;

		private Matcher matcher;

		private Aggregator aggregator;

		public TextSearching(string fileName, params string[] words)
		{
			CHUNK_SIZE = GetChunkSizeFromEnvironment() ?? CHUNK_SIZE; // Get CHUNK_SIZE from global environment if set

			Console.WriteLine("Searching: " + fileName + " - Words Lengh: " + words.Length + " - Chunk Size: " + CHUNK_SIZE);

			matcher = new Matcher(words);

			fr = new FileReader(fileName, CHUNK_SIZE);

			aggregator = new Aggregator();
		}

		public IDictionary<string, IList<PhraseMatch>> Start()
		{
			int previousCharCount = 0; // In order to fix chunk details, because the "search" works on independent chunks

			Nullable<TextChunk> chunk;

			while ((chunk = fr.GetChunk()).HasValue)
			{
				// Console.WriteLine("\n\nText Chunk: " + " - Chunk: " + chunk.ChunkNumber + " - LinesCount: " + chunk.LinesCount + " - CharsCount: " + chunk.CharsCount);

				IList<PhraseMatch> matches = matcher.Search(chunk.Value.Text);

				AddResults(chunk.Value.ChunkNumber, previousCharCount, matches);

				previousCharCount += chunk.Value.CharsCount;
			}

			return aggregator.GetResults();
		}

		private void AddResults(int chunk, int previousCharCount, IList<PhraseMatch> matches)
		{
			foreach (PhraseMatch m in matches)
			{
				// Fix values, calculating the chunks
				m.UpdateFields(m.CharOffset + previousCharCount, m.Line + (chunk * CHUNK_SIZE));

				aggregator.AddOrUpdateResults(m);

				// Console.WriteLine("CharOffset: " + m.CharOffset + " - Line: " + m.Line + " - LineOffset: " + m.LineOffset + " - Word: " + m.Word);
			}
		}

		private int? GetChunkSizeFromEnvironment()
		{
			int chunkSize = -1;
			string envChunkSize = Environment.GetEnvironmentVariable("CHUNK_SIZE");

			if (!int.TryParse(envChunkSize, out chunkSize)) // If parse fails returns null
			{
				return null;
			}

			if (chunkSize < MIN_CHUNK_SIZE) // Validate minimum chunk_size! Too Small chunk size is not recommended
			{
				return null;
			}

			return chunkSize;
		}


	}
}
