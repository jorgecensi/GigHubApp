using System;
using System.Windows.Input;
using GigHubApp.Services;
using Xamarin.Forms;

namespace GigHubApp.ViewModels
{
    public class LoginViewModel
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
                    await _apiServices.LoginAsync(Username, Password);
                });
            }
        }
    }
}
