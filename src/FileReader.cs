using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace search_text
{
	class FileReader
	{
		private IEnumerable<string> lines;

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
				lines = File.ReadLines(filePath, Encoding.UTF8);
			}
			catch (FileNotFoundException ioEx)
			{
				Console.WriteLine("Error reading the file. " + ioEx.Message);

				throw new Exception("Error reading the file");
			}
		}

		public IEnumerable<string> Read()
		{
			try
			{
				IEnumerable<string> lines = File.ReadLines(filePath, Encoding.UTF8);

				int count = 0;
				foreach (string line in lines)
				{
					count++;
				}

				Console.WriteLine("Lines Total: " + count);
			}
			catch (FileNotFoundException ioEx)
			{
				Console.WriteLine("Error reading the file. " + ioEx.Message);

				throw new Exception("Error reading the file");
			}
		}
		
		public IEnumerable<string> GetChunk()
		{
			int count = 1;
			IList<string> chunk = new List<string>();

			foreach (string line in lines)
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

