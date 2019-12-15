using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UriSender
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		private IOpenAppService _service;

		public MainPage(IOpenAppService service)
		{
			InitializeComponent();

			_service = service;
		}

		private async void OpenAppService_OnClicked(object sender, EventArgs e)
		{
			var result = await _service.Launch(Uri.Text);

		}

		private void DeviceOpenUrl_OnClicked(object sender, EventArgs e)
		{
			try
			{
				Device.OpenUri(new Uri(Uri.Text));
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception);
				throw;
			}
			 
		}

		private async void BrowserOpenAsync_OnClicked(object sender, EventArgs e)
		{
			var result = await Browser.OpenAsync(new Uri(Uri.Text), new BrowserLaunchOptions() {LaunchMode = BrowserLaunchMode.External});
		}

		private async void LauncherOpenAsync_OnClicked(object sender, EventArgs e)
		{
			var canOpen = await Launcher.CanOpenAsync(new Uri(Uri.Text));
			if (canOpen)
			{
				await Launcher.OpenAsync(new Uri(Uri.Text));
			}
		}
	}
}
