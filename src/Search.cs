using System;
using System.Collections.Generic;

namespace search_text
{
	class TextSearching
	{
        FileReader fr;

		public TextSearching(string fileName)
		{
			Console.WriteLine("Searching: " + fileName);

			fr = new FileReader(fileName, 100);
		}

		public void start()
		{			
            IList<string> lines = fr.GetChunk();

            while(lines.Count > 0){
                foreach(string line in lines){
                    Console.WriteLine(line);
                }

                lines = fr.GetChunk();
            }            			
		}
	}
}
