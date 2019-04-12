using System.Windows.Input;
using GigHubApp.Services;
using Xamarin.Forms;
using Xamarin.Essentials;
using GigHubApp.Helpers;

namespace GigHubApp.ViewModels
{
    public class RegisterViewModel: BaseViewModel
    {
        ApiServices _apiServices = new ApiServices();
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }

        public RegisterViewModel()
        {
            Title = "Register";
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isSuccess = await _apiServices.RegisterAsync(Name, Email, Password, ConfirmPassword);

                    Settings.Username = Email;
                    Settings.Password = Password;
                    if (isSuccess)
                        Message = "Registered successfully";
                    else
                        Message = "Retry later";
                });
            }
        }
    }
}
