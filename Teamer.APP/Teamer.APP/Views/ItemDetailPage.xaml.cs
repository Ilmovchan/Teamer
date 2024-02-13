using System.ComponentModel;
using Teamer.APP.ViewModels;
using Xamarin.Forms;

namespace Teamer.APP.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}