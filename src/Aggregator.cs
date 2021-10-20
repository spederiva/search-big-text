using System;
using System.Collections.Generic;

namespace search_text
{
	class Aggregator
	{

		private IDictionary<string, IList<PhraseMatch>> results;

		public Aggregator()
		{
			results = new Dictionary<string, IList<PhraseMatch>>();
		}

		public void AddOrUpdateResults(PhraseMatch match)
		{
			if (!results.ContainsKey(match.Word))
			{
				results.Add(match.Word, new List<PhraseMatch>());
			}

			results[match.Word].Add(match);
		}

		public IDictionary<string, IList<PhraseMatch>> GetResults()
		{
			return results;
		}
	}
}