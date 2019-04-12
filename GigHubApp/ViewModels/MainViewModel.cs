using System;
using System.Windows.Input;
using GigHubApp.Helpers;
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
                    Settings.Clear();
                    await PushAsync<LoginViewModel>();
                    IsBusy = false;
                });
            }
        }
    }
}
