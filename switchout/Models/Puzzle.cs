using System;

namespace switchout
{
	public class Puzzle
	{
		readonly int level;

		readonly int[][] puzzle;

		public int LevelNumber { get { return level; } }

		public int[][] PuzzleSequence { get { return puzzle; } }

		public Puzzle(int level, int[] sequence)
		{
			this.level = level;

			// Check that the given sequence size is a perfect square
			var size = (int) Math.Sqrt(sequence.Length);
			if (Math.Abs(size % 1) > 0)
				throw new Exception(
					"The sequence size given to the Puzzle() constructor is not a perfect square number");

			// Generate the puzzle array
			puzzle = new int[size][];
			int index = 0;
			for (int i = 0; i < size; i++)
			{
				puzzle[i] = new int[size];
				for (int j = 0; j < size; j++)
					puzzle[i][j] = sequence[index++];
			}
		}



	}
}
