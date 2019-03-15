using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using GigHubApp.Models;
using GigHubApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GigHubApp.ViewModels
{
    public class GigsViewModel : BaseViewModel
    {
        ApiServices _apiServices = new ApiServices();
        private List<Gig> _gigs;

        public List<Gig> Gigs { 
            get => _gigs;
            set {
                _gigs = value;
                OnPropertyChanged();
            } }

        public GigsViewModel()
        {
            Title = "Gigs";
        }
        public override async Task LoadAsync()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            var accessToken = Preferences.Get("accessToken", "");
            Gigs = await _apiServices.GetGigsAsync(accessToken);
            IsBusy = false;
        }

    }
}
