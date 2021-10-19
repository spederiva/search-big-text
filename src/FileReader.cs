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

		private int chunkNumber = 0;

		public FileReader(string _filePath, int _chunkSize = 1000)
		{
			Console.WriteLine("Initializing FileReader for file: ", _filePath);

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

		public TextChunk GetChunk()
		{
			StringBuilder sb = new StringBuilder();

			string line = "";
			int lineCounter = 1;

			while ((line = reader.ReadLine()) != null)
			{
				sb.AppendLine(line);

				lineCounter++;

				if (lineCounter > chunkSize)
				{
					break;
				}
			}

			// TODO: Call dispose!

			return new TextChunk(sb.ToString(), chunkNumber++, lineCounter - 1);
		}
	}
}

