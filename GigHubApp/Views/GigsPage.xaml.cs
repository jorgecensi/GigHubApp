
using GigHubApp.Models;
using GigHubApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace GigHubApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GigsPage : BasePage
    {
        private async void Handle_ItemTappedAsync(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var gig = e.Item as Gig;
            await Navigation.PushAsync(new EditGigPage(gig));
        }

        public GigsPage()
        {
            InitializeComponent();
            BindingContext = new GigsViewModel();
        }
    }
}
