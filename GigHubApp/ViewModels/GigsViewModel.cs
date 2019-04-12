using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using GigHubApp.Helpers;
using GigHubApp.Models;
using GigHubApp.Services;
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
            var accessToken = Settings.AccessToken;
            Gigs = await _apiServices.GetGigsAsync(accessToken);
            IsBusy = false;
        }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () => 
                {
                    await PushAsync<AddGigViewModel>();
                
                });
            }
        }
        public async void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Gig tappedGig = e.Item as Gig;
            if (tappedGig == null)
                return;
            await PushAsync<EditGigViewModel>(tappedGig);
        }
    }
}
