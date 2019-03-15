using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GigHubApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
        }
        public ICommand LogoutCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (IsBusy)
                        return;
                    IsBusy = true;
                    Preferences.Set("accessToken", "");
                    Preferences.Set("username", "");
                    Preferences.Set("password", "");
                    await PushAsync<LoginViewModel>();
                    IsBusy = false;
                });
            }
        }
    }
}
