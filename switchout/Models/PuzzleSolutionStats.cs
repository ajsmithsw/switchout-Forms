using SQLite;

namespace switchout
{
	public class PuzzleSolutionStats
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public int Level { get; set; }

		public int Par { get; set; }

		public int BestScore { get; set; }

		public int Stars { get; set; }


		public PuzzleSolutionStats() { }

		public PuzzleSolutionStats(int level, int par, int score, int stars)
		{
			Level = level;
			Par = par;
			BestScore = score;
			Stars = stars;
		}
	}
}
