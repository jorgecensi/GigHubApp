using System;
using System.Collections.Generic;
using System.Windows.Input;
using GigHubApp.Helpers;
using GigHubApp.Models;
using GigHubApp.Services;
using Xamarin.Forms;

namespace GigHubApp.ViewModels
{
    public class AddGigViewModel: BaseViewModel
    {
        readonly ApiServices _apiServices = new ApiServices();

        public int Id { get; private set; }

        public ApplicationUser Artist { get; set; }

        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        public string Venue { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        private List<Genre> genres = new List<Genre>();

        public AddGigViewModel()
        {
            Title = "Add Gig";
            Genres.Add(new Genre {Id= 1, Name = "genre1" });
            Genres.Add(new Genre {Id=2,  Name = "genre2" });
            Genres.Add(new Genre {Id=3,  Name = "genre3" });
            Genres.Add(new Genre {Id=4,  Name = "genre4" });
            DateTime = DateTime.Now;
        }
        public List<Genre> Genres { get => genres; set => genres = value; }

        int genresSelectedIndex;
        public int SelectedGenreIndex
        {
            get
            {
                return genresSelectedIndex;
            }
            set
            {
                genresSelectedIndex = value;
                Genre = Genres[genresSelectedIndex]; 
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () => 
                {
                    if (IsBusy)
                        return;
                    IsBusy = true;
                    var gig = new Gig() 
                    { 
                        Venue = Venue,
                        DateTime = DateTime,
                        GenreId = Genre.Id
                    };
                    var accessToken = Settings.AccessToken;
                    await _apiServices.PostGigAsync(gig, accessToken);
                    await PushAsync<MainViewModel>();
                    IsBusy = false;

                });
            }
        }


    }
}
