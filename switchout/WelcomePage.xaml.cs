using System;

using Xamarin.Forms;

namespace switchout
{
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage()
		{
			InitializeComponent();
		}

		async void PlayButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new GamePage());
		}
	}
}
