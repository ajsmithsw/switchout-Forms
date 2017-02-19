using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace switchout
{
	public partial class GamePage : ContentPage
	{
		public GamePage()
		{
			InitializeComponent();

			var level = new int[][] {
				new int[] { 0, 0, 0, 0, 0 },
				new int[] { 0, 0, 1, 0, 0 },
				new int[] { 0, 1, 1, 1, 0 },
				new int[] { 0, 0, 1, 0, 0 },
				new int[] { 0, 0, 0, 0, 0 }
			};

			PopulateLightGrid(level);
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
			(sender as Light).Toggle();

			var row = (sender as Light).position[0];
			var col = (sender as Light).position[1];

			foreach (Light light in lights.Children)
				if (ShouldToggle(light.position, row, col))
					light.Toggle();

			if (CheckHasWon())
				DisplayAlert("Congratulations", "You win!", "");
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

	}
}
