using System.Windows.Input;
using GigHubApp.Services;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace GigHubApp.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        private ApiServices _apiServices = new ApiServices();
        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var accessToken = await _apiServices.LoginAsync(Username, Password);
                    Preferences.Set("accessToken", accessToken);
                    await PushAsync<GigsViewModel>();
                });
            }
        }

        public LoginViewModel()
        {
            Title = "Login";
            Username = Preferences.Get("username", "");
            Password = Preferences.Get("password", "");
        }
    }
}
