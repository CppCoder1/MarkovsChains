using System;
using System.Collections.Generic;
using System.IO;

namespace MarkovChains
{
	class Program
	{
		static Random rnd = new();
		static void Main()
		{
			string path = @"C:\Users\SGoni\Desktop\chehov.txt";
			string text = File.ReadAllText(path);

			string[] Words = text.Split(" ");
			Dictionary<string, Value> TextElements = new();

			TextElements.Add(Words[0], new Value());

			for (int i = 1; i < Words.Length; i++)
			{
				if (TextElements.ContainsKey(Words[i]))
				{
					int ind = Array.IndexOf(Words, Words[i]) - 1;
					if (ind == 0)
						continue;
					var b = TextElements[Words[ind]];
					var c = TextElements[Words[ind]].Words.IndexOf(Words[i]);
					int index = ++TextElements[Words[ind]]
						.CountWordOf[TextElements[Words[ind]]
						.Words.IndexOf(Words[i])];

					TextElements[Words[i - 1]].Words.Add(Words[i]);
					TextElements[Words[i - 1]].CountWordOf.Add(index);
				}
				else
				{
					TextElements.Add(Words[i], new Value());
					TextElements[Words[i - 1]].Words.Add(Words[i]);
					TextElements[Words[i - 1]].CountWordOf.Add(1);
				}
			}

			string lastWord = Words[0];
			Console.Write(lastWord + " ");
			int l = 0;
			while (l++ < 1000)
			{
				if (TextElements[lastWord].Words.Count == 1)
				{
					lastWord = TextElements[lastWord].Words[0];
				}
				else if(TextElements[lastWord].Words.Count == 0)
				{
					lastWord = Words[new Random().Next(Words.Length / 10)];
				}
				else
				{
					var index = GetRandIndex(TextElements[lastWord].GetCountAll(), TextElements[lastWord].CountWordOf);
					lastWord = TextElements[lastWord].Words[index];
				}
				Console.Write(lastWord + " ");
			}
		}

		static int GetRandIndex(int N, List<int> counts)
		{
			int next = rnd.Next(N);

			for(int i = 0; i < counts.Count - 1; i++)
			{
				if (next <= counts[i + 1] * (i + 1) && next > counts[i] * i)
					return i;
			}
			return 0;
		}
	}
}
