using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;

namespace switchout
{
	public partial class App : Application
	{
		static GameProgressDatabase database;

		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new WelcomePage());
		}

		public static GameProgressDatabase Database 
		{ 
			get 
			{
				if (database == null)
				{
					database = new GameProgressDatabase(
						DependencyService.Get<IFileHelper>().GetLocalFilePath("switchout_database.db3") );
				}
				return database;
			} 
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
