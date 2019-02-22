using System;
using System.Collections.Generic;
using System.Windows.Input;
using GigHubApp.Models;
using GigHubApp.Services;
using Xamarin.Forms;

namespace GigHubApp.ViewModels
{
    public class GigsViewModel : BaseViewModel
    {
        ApiServices _apiServices = new ApiServices();
        private List<Gig> _gigs;

        public string AccessToken { get; set; }
        public List<Gig> Gigs { 
            get => _gigs;
            set {
                _gigs = value;
                OnPropertyChanged();
            } }
        public ICommand GetGigs
        {
            get
            {
                return new Command(async () =>
                {
                    Gigs = await _apiServices.GetGigsAsync(AccessToken);
                });
            }
        }
    }
}
