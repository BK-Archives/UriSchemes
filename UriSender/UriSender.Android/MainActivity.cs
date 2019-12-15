using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;

namespace UriSender.Droid
{
    [Activity(Label = "UriSender", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            var app = new App();

			app.LoadApp(new OpenAppService());

            LoadApplication(app);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

   
	// https://mindofai.github.io/Launching-Apps-thru-URI-with-Xamarin.Forms/
    public class OpenAppService : Activity, IOpenAppService
    {
	    public Task<bool> Launch(string stringUri)
	    {
		    try
		    {
			    Intent intent = Android.App.Application.Context.PackageManager.GetLaunchIntentForPackage(stringUri);

			    if (intent != null)
			    {
				    intent.AddFlags(ActivityFlags.NewTask);
				    Forms.Context.StartActivity(intent);
			    }
			    else
			    {
				    intent = new Intent(Intent.ActionView);
				    intent.AddFlags(ActivityFlags.NewTask);
				    intent.SetData(
					    Android.Net.Uri
						    .Parse(stringUri)); // This launches the PlayStore and search for the app if it's not installed on your device
				    Forms.Context.StartActivity(intent);
			    }

			    return Task.FromResult(true);
		    }
		    catch (Exception e)
		    {
			    return Task.FromResult(false);
		    }

	    }
    }
}

   