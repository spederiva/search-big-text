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

			// Sample in case need to ignore word case
			// IEnumerable<WordMatch> results = "AbCcab".Contains(CharComparer.OrdinalIgnoreCase, "a", "ab", "c").ToList();

			IList<PhraseMatch> matches = new List<PhraseMatch>();

			int LineNumber = 1; // Store line number because AhoCorasick algorith doesn't return it
			int LastEnterIndex = 0; // Store last carriege return in order to calculate LineOffset

			foreach (WordMatch r in results)
			{
				// Console.WriteLine("CharOffset: " + r.Index + " - Word: " + r.Word.Replace("\n", "ENTER"));

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

			return matches;
		}
	}
}