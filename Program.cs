using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace search_text
{
	class Program
	{
		static void Main(string[] args)
		{
			string fileName = args[0];
			// fileName = "/Users/sebastian/Developer/dotnet-core/search-text/search-text/assets/full_2020_10_28_com.csv";
			// fileName = "/Users/sebastian/Developer/dotnet-core/search-text/search-text/assets/text.txt";
			// fileName = "/Users/sebastian/Developer/dotnet-core/search-text/search-text/assets/small_text.txt";

			Console.WriteLine("Starting to Search Fast for file: " + fileName);			

			Stopwatch sp = new Stopwatch();
			sp.Start();

			TextSearching textSearching = new TextSearching(fileName, args.Skip(1).ToArray());
			IDictionary<string, IList<PhraseMatch>> results = textSearching.Start();

			sp.Stop();

			Console.WriteLine("Elapsed Time is {0} ms", sp.ElapsedMilliseconds);

			PrintResults(results);
		}

		private static void PrintResults(IDictionary<string, IList<PhraseMatch>> results)
		{
			StringBuilder res = new StringBuilder();
			foreach (KeyValuePair<string, IList<PhraseMatch>> result in results)
			{
				res.Append(result.Key);
				res.Append(" --> ");

				foreach (PhraseMatch match in result.Value)
				{
					res.AppendFormat("[Line: {0}, LineOffset: {1}, CharOffset: {2}]", match.Line, match.LineOffset, match.CharOffset);
				}

				res.AppendLine("");
			}

			Console.WriteLine(res.ToString());
		}
	}
}
