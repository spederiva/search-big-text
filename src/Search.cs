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

			matcher = new Matcher();
			fr = new FileReader(fileName, 100);
		}

		public void start()
		{
			string lines = fr.GetChunk();

			while (lines.Length > 0)
			{
				IList<PhraseMatch> matches = matcher.Search(lines);

				foreach (PhraseMatch m in matches)
				{
					Console.WriteLine("CharOffset: " + m.CharOffset + " - Line: " + m.Line + " - LineOffset: " + m.LineOffset + " - Word: " + m.Word);
				}

				lines = fr.GetChunk();
			}
		}
	}
}
