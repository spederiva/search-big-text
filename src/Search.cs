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
            IEnumerable<string> lines = fr.GetChunk();

            while(lines != null){
                foreach(string line in lines){
                    Console.WriteLine(line);
                }

                lines = fr.GetChunk();
            }            			
		}
	}
}
