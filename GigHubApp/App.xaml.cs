using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GigHubApp.Views;
using Xamarin.Essentials;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GigHubApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            SetMainPage();
            //MainPage = new NavigationPage(new RegisterPage());
        }

        private void SetMainPage()
        {
            if (!string.IsNullOrEmpty(Preferences.Get("accessToken", "") ))
            {
                MainPage = new MainPage();
            }
            else if (!string.IsNullOrEmpty(Preferences.Get("username", ""))
                    && !string.IsNullOrEmpty(Preferences.Get("password", "")))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new RegisterPage());
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
