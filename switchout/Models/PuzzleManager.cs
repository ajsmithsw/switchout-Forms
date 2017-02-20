using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace switchout
{
	public static class PuzzleManager
	{
		public static List<Puzzle> GetPuzzles()
		{
			var puzzles = new List<Puzzle>();

			var assembly = typeof(PuzzleManager).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("switchout.Puzzles.txt");


			using (var reader = new StreamReader(stream))
			{
				int level = 0;
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					var digits = line.ToCharArray();

					var puzzleSequence = new List<int>();

					for (int i = 0; i < digits.Length; i++)
					{
						if (digits[i] == '0')
							puzzleSequence.Add(0);
						if (digits[i] == '1')
							puzzleSequence.Add(1);
					}

					puzzles.Add(new Puzzle(level++, puzzleSequence.ToArray()));
				}
			}

			return puzzles;
		}
	}
}
