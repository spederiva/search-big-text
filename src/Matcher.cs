using System;
using System.Collections.Generic;
using Ganss.Text;
using System.Linq;

namespace search_text
{
	class Matcher
	{
		AhoCorasick ac;

		public Matcher(params string[] words)
		{
			// Added carriege return in order to calculate lines
			var newWords = words.Append("\n");

			ac = new AhoCorasick(newWords);
		}

		public IList<PhraseMatch> Search(string text)
		{
			IEnumerable<WordMatch> results = ac.Search(text);

			// Sample in case need to ignore word case
			// IEnumerable<WordMatch> results = "AbCcab".Contains(CharComparer.OrdinalIgnoreCase, "a", "ab", "c").ToList();

			IList<PhraseMatch> matches = new List<PhraseMatch>();

			int lineNumber = 1; // Store line number because AhoCorasick algorith doesn't return it
			int lastEnterIndex = 0; // Store last carriege return in order to calculate LineOffset

			foreach (WordMatch r in results)
			{
				if (r.Word == "\n")
				{
					lineNumber++;
					lastEnterIndex = r.Index;

					continue;
				}

				// TODO: Make sure the word fully matches exactly the text and not only part of it. Check for stop words!
				matches.Add(new PhraseMatch(r.Word, r.Index, lineNumber, r.Index - lastEnterIndex));
			}

			return matches;
		}
	}
}