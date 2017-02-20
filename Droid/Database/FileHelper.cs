using System;
using Xamarin.Forms;
using switchout.Droid;
using System.IO;

[assembly: Dependency(typeof(FileHelper))]
namespace switchout.Droid
{
	public class FileHelper
	{
		public string GetLocalFilePath(string filename)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return Path.Combine(path, filename);
		}
	}
}
