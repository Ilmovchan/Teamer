using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamer.APP.Models;
using Teamer.APP.ViewModels;
using Teamer.APP.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teamer.APP.Views
{
    public partial class TeamsPage : ContentPage
    {
        TeamsViewModel _viewModel;

        public TeamsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new TeamsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}