using System.Windows.Input;
using GigHubApp.Services;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace GigHubApp.ViewModels
{
    public class RegisterViewModel
    {
        ApiServices _apiServices = new ApiServices();
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isSuccess = await _apiServices.RegisterAsync(Name, Email, Password, ConfirmPassword);

                    Preferences.Set("username", Email);
                    Preferences.Set("password", Password);
                    if (isSuccess)
                        Message = "Registered successfully";
                    else
                        Message = "Retry later";
                });
            }
        }
    }
}
