using System;
using System.Collections.Generic;

namespace search_text
{
	class TextSearching
	{
		FileReader fr;
		Matcher matcher;

		public TextSearching(string fileName)
		{
			Console.WriteLine("Searching: " + fileName);

			matcher = new Matcher("sebastian", "Shir", "Paul", "Boone", "Autism");

			fr = new FileReader(fileName, 100);
		}

		public void start()
		{
			TextChunk chunk = fr.GetChunk();

			Console.WriteLine("Text Chunk: " + " - Chunk: " + chunk.ChunkNumber + " - LinesCount: " + chunk.LinesCount + " - CharsCount: " + chunk.CharsCount);

			while (chunk.Text.Length > 0)
			{
				IList<PhraseMatch> matches = matcher.Search(chunk.Text);

				foreach (PhraseMatch m in matches)
				{
					Console.WriteLine("CharOffset: " + m.CharOffset + " - Line: " + m.Line + " - LineOffset: " + m.LineOffset + " - Word: " + m.Word);
				}

				chunk = fr.GetChunk();

			Console.WriteLine("Text Chunk: " + " - Chunk: " + chunk.ChunkNumber + " - LinesCount: " + chunk.LinesCount + " - CharsCount: " + chunk.CharsCount);
			}
		}



	}
}
