using System;

namespace search_text
{
    class Program
    {
        static void Main(string[] args)
        {
            string myname = args[0];

            Console.WriteLine("Hello World!" + myname);

            FileReader fr = new FileReader("/Users/sebastian/Developer/dotnet-core/search-text/search-text/assets/full_2020_10_28_com.csv", 100);

            var bytes = fr.GetChunk();

            Console.WriteLine("Bytes: " + bytes.ToString());
        }
    }
}
