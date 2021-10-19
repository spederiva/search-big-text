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

		public IList<PhraseMatch> Search(string text)
		{
			IEnumerable<WordMatch> results = ac.Search(text);

			IList<PhraseMatch> matches = new List<PhraseMatch>();

			int LineNumber = 1;
			int LastEnterIndex = 0;

			foreach (WordMatch r in results)
			{
				Console.WriteLine("CharOffset: " + r.Index + " - Word: " + r.Word.Replace("\n", "ENTER"));

				if(r.Word == "\n"){
					LineNumber++;
					LastEnterIndex = r.Index;

					continue;
				}

				matches.Add(new PhraseMatch()
				{
					Word = r.Word,
					CharOffset = r.Index,
					Line = LineNumber,
					LineOffset = r.Index - LastEnterIndex
				});

			}

			// var results = "abccab".Contains("a", "ab", "bab", "bc", "bca", "c", "caa").ToList();

			return matches;

		}
	}
}