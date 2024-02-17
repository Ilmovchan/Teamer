using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Input;
using Teamer.APP.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Teamer.APP.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public string UserName
        {
            get { return App.UserController.CurrentUser.Name; }
        }

        public MainViewModel()
        {
            Title = "Main";
        }
    }
}