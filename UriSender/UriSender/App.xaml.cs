using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UriSender
{
	public interface IOpenAppService
	{
		Task<bool> Launch(string stringUri);
	}

	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

		}

		public void LoadApp(IOpenAppService service)
		{
			MainPage = new MainPage(service);
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
