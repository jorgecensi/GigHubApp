
using GigHubApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace GigHubApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GigsPage : BasePage
    {


        public GigsPage()
        {
            InitializeComponent();
            BindingContext = new GigsViewModel();
        }
    }
}
