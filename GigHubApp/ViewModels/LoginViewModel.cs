using System.Windows.Input;
using GigHubApp.Services;
using Xamarin.Forms;
using GigHubApp.Helpers;

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
                    if (IsBusy)
                        return;
                    IsBusy = true;
                    var accessToken = await _apiServices.LoginAsync(Username, Password);
                    Settings.AccessToken = accessToken;
                    await PushAsync<GigsViewModel>();
                    IsBusy = false;
                });
            }
        }

        public LoginViewModel()
        {
            Title = "Login";
            Username = Settings.Username;
            Password = Settings.Username;
        }
    }
}
