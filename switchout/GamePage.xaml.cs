using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace switchout
{
	public partial class GamePage : ContentPage
	{
		public int level, moves, par;
		List<Puzzle> puzzles;
		List<PuzzleSolutionStats> levelsComplete;


		public GamePage()
		{
			InitializeComponent();

			InitializeLevel();
		}

		async void InitializeLevel()
		{
			puzzles = PuzzleManager.GetPuzzles();

			levelsComplete = await App.Database.GetItemsAsync();

			level = levelsComplete.Count + 1;
			if (level > puzzles.Count)
				level = 1;
			
			moves = 0;

			lblLevelNumber.Text = string.Format("Level {0}", level);
			lblMovesMade.Text = string.Format("Moves {0}", moves);

			PopulateLightGrid(puzzles[levelsComplete.Count].PuzzleSequence);

			// TODO - par = GetParForPuzzleSequence();
		}

		public void PopulateLightGrid(int[][] level)
		{
			for (int i = 0; i < level.Length; i++)
				for (int j = 0; j < level[i].Length; j++)
				{
					var light = new Light(i, j, level[i][j]);
					light.Clicked += LightPressed;
					lights.Children.Add(light, i, j);
				}
		}

		void LightPressed(object sender, EventArgs e)
		{
			lblMovesMade.Text = string.Format("Moves {0}", ++moves);

			(sender as Light).Toggle();

			var row = (sender as Light).position[0];
			var col = (sender as Light).position[1];

			foreach (Light light in lights.Children)
				if (ShouldToggle(light.position, row, col))
					light.Toggle();

			if (CheckHasWon())
			{
				DisplayAlert("Congratulations", "You win!", "Next");

				// Save the stats for the level
				App.Database.SaveItemAsync(new PuzzleSolutionStats(level, 0, moves, 3));

				// Generate next level
				SetLevel(level + 1);
			}
		}

		bool ShouldToggle(int[] position, int row, int col)
		{
			var x = position[0]; 
			var y = position[1];
			if ((x == row - 1 && y == col) ||
				(x == row + 1 && y == col) ||
				(x == row && y == col - 1) ||
				(x == row && y == col + 1))
				return true;
			return false;
		}

		bool CheckHasWon()
		{
			foreach (Light light in lights.Children)
				if (light.Illuminated())
					return false;
			return true;
		}

		void SetLevel(int newLevel)
		{

			if (newLevel > puzzles.Count)
			{
				DisplayAlert("Complete!", "You've solved all of the puzzles!", "OK");
				newLevel = 1;
				moves = 0;
				// TODO - par, best, etc
			}
			else
			{
				level = newLevel;
				moves = 0;

				lblLevelNumber.Text = string.Format("Level {0}", level);
				lblMovesMade.Text = string.Format("Moves {0}", moves);
				// TODO - par, best etc
			}

			foreach (Light light in lights.Children)
			{
				var x = light.position[0];
				var y = light.position[1];

				if (puzzles[level].PuzzleSequence[x][y] == 0 && light.Illuminated())
					light.Toggle();
				if (puzzles[level].PuzzleSequence[x][y] == 1 && !light.Illuminated())
					light.Toggle();
			}
		}
	}
}
