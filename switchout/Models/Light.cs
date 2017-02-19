using System;
using Xamarin.Forms;

namespace switchout
{
	public class Light : Button
	{
		public int[] position { get; private set; }

		int _illuminated;

		public Light(int row, int column, int illuminated)
		{
			position = new int[2] { row, column };
			_illuminated = illuminated;
			BorderRadius = 5;
			SetBackgroundColor();
		}

		public bool Illuminated() => _illuminated == 1;

		public void Toggle()
		{
			if (_illuminated == 0)
				_illuminated = 1;
			else
				_illuminated = 0;

			SetBackgroundColor();
		}

		void SetBackgroundColor()
		{
			BackgroundColor = _illuminated == 1 ? Color.Yellow : Color.Gray;
		}
	}
}
