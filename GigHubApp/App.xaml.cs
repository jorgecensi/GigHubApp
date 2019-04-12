using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GigHubApp.Views;
using GigHubApp.Helpers;

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
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                MainPage = new MainPage();
            }
            else if (!string.IsNullOrEmpty(Settings.Username)
                    && !string.IsNullOrEmpty(Settings.Password))
            {
                MainPage = new LoginPage();
            }
            else
            {
                MainPage = new RegisterPage();
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
