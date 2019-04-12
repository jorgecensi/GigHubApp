using System;
using GigHubApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GigHubApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : BasePage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}
