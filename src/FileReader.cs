using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace search_text
{
	class FileReader
	{
		private StreamReader reader;

		private int chunkSize;

		public FileReader(string _filePath, int _chunkSize = 1000)
		{
			Console.WriteLine("Initializing FileReader", _filePath);

			chunkSize = _chunkSize;

			OpenFile(_filePath);
		}

		private void OpenFile(string filePath)
		{
			try
			{
				reader = new StreamReader(filePath);
			}
			catch (FileNotFoundException ioEx)
			{
				Console.WriteLine("Error reading the file. " + ioEx.Message);

				throw new Exception("Error reading the file");
			}
		}

		private void Close()
		{
			// Close and ensure is release the memory calling "Dispose"

			reader.Close();
			reader.Dispose();
		}

		public IList<string> GetChunk()
		{
			int count = 1;
			IList<string> chunk = new List<string>();

			string line;
			while ((line = reader.ReadLine()) != null)
			{
				chunk.Add(line);

				count++;

				if (count > chunkSize)
				{
					break;
				}
			}		

			return chunk;
		}
	}
}

