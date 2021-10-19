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
				matcher.Search(lines);

				// foreach (string line in lines)
				// {
					// Console.WriteLine(line);

				// }

				lines = fr.GetChunk();
			}
		}
	}
}
