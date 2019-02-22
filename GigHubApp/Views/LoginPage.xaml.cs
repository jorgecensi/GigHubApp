
using GigHubApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GigHubApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : BasePage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
