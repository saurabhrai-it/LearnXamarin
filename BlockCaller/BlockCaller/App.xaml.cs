using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlockCaller.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BlockCaller
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new BlockCalls())
                    {
                        Title = "Block Calls",
                        //Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                    new NavigationPage(new BlockedList())
                    {
                        Title = "Blocked List",
                        //Icon = Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new RecordCalls())
                    {
                        Title = "Record Calls",
                        //Icon = Device.OnPlatform("tab_feed.png",null,null)
                    }
                }
            };
        }

  //      protected override void OnStart ()
		//{
		//	// Handle when your app starts
		//}

		//protected override void OnSleep ()
		//{
		//	// Handle when your app sleeps
		//}

		//protected override void OnResume ()
		//{
		//	// Handle when your app resumes
		//}
	}
}
