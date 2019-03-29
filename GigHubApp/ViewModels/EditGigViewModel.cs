using System;
using System.Collections.Generic;
using System.Windows.Input;
using GigHubApp.Models;
using GigHubApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GigHubApp.ViewModels
{
    public class EditGigViewModel:BaseViewModel
    {
        public ApiServices _apiServices = new ApiServices();
        public Gig Gig { get; set; }
        private List<Genre> genres = new List<Genre>();
        public EditGigViewModel(Gig gig)
        {
            Gig = gig;
            Genres.Add(new Genre { Id = 1, Name = "genre1" });
            Genres.Add(new Genre { Id = 2, Name = "genre2" });
            Genres.Add(new Genre { Id = 3, Name = "genre3" });
            Genres.Add(new Genre { Id = 4, Name = "genre4" });
            Gig.DateTime = DateTime.Now;
        }
        public List<Genre> Genres { get => genres; set => genres = value; }
        public ICommand EditCommand
        {
            get
            {
                return new Command(async() => 
                {
                    var accessToken = Preferences.Get("accessToken", "");
                    await _apiServices.PutGigAsync(Gig, accessToken);
                });
            }

        }
    }
}
