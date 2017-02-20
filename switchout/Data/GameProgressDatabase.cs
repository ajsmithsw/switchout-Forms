using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace switchout
{
	public class GameProgressDatabase
	{
		readonly SQLiteAsyncConnection database;

		public GameProgressDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<PuzzleSolutionStats>().Wait();
		}

		public Task<List<PuzzleSolutionStats>> GetItemsAsync()
		{
			return database.Table<PuzzleSolutionStats>().ToListAsync();
		}

		//public Task<List<PuzzleSolutionStats>> GetItemsNotDoneAsync()
		//{
		//	return database.QueryAsync<PuzzleSolutionStats>("SELECT * FROM [PuzzleSolutionStats] WHERE [Done] = 0");
		//}

		public Task<PuzzleSolutionStats> GetItemAsync(int id)
		{
			return database.Table<PuzzleSolutionStats>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(PuzzleSolutionStats item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
				
			return database.InsertAsync(item);
		}

		public Task<int> DeleteItemAsync(PuzzleSolutionStats item)
		{
			return database.DeleteAsync(item);
		}
	}
}
