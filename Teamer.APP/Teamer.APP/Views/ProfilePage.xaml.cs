using Teamer.APP.ViewModels;
using Xamarin.Forms;

namespace Teamer.APP.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            this.BindingContext = new ProfileViewModel();
        }
    }
}