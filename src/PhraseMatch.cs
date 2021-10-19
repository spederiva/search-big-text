namespace search_text
{
	public struct PhraseMatch
	{
		public string Word { readonly get; set; }

        public int CharOffset{ readonly get; set; }

		public int Line { readonly get; set; }

		public int LineOffset { readonly get; set; }       

	}
}