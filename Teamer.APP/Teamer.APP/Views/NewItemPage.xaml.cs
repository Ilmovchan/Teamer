using System;
using System.Collections.Generic;
using System.ComponentModel;
using Teamer.APP.Models;
using Teamer.APP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teamer.APP.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}