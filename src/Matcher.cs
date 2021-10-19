using System;
using System.Collections.Generic;
using Ganss.Text;

namespace search_text
{
	class Matcher
	{
        AhoCorasick ac;

		public Matcher(params string[] words)
		{
			ac = new AhoCorasick("sebastian", "Shir", "Paul", "\n");
		}

		public void Search(string text)
		{
			IEnumerable<WordMatch> results = ac.Search(text);

			foreach (WordMatch r in results)
			{
				Console.WriteLine("Index: " + r.Index + " - Word: " + r.Word);
			}

			// var results = "abccab".Contains("a", "ab", "bab", "bc", "bca", "c", "caa").ToList();

		}
	}
}