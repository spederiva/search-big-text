using System;
using System.Diagnostics;

namespace search_text
{
	class Program
	{
		static void Main(string[] args)
		{
			string fileName = args[0];
			// fileName = "/Users/sebastian/Developer/dotnet-core/search-text/search-text/assets/full_2020_10_28_com.csv";
			// fileName = "/Users/sebastian/Developer/dotnet-core/search-text/search-text/assets/text.txt";
			fileName = "/Users/sebastian/Developer/dotnet-core/search-text/search-text/assets/small_text.txt";

			Console.WriteLine("Starting to Search Fast for file: " + fileName);

			Stopwatch sp = new Stopwatch();
			sp.Start();

			TextSearching textSearching = new TextSearching(fileName);
			textSearching.start();

			sp.Stop();

			Console.WriteLine("Elapsed Time is {0} ms", sp.ElapsedMilliseconds);
		}
	}
}
