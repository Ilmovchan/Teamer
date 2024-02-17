using System;

namespace Teamer.APP.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {

        public string UserName 
        {
            get { return App.UserController.CurrentUser.Name; }
        }

        public string Email
        {
            get { return App.UserController.CurrentUser.Email ?? "Not set"; }
        }

        public string Phone
        {
            get { return App.UserController.CurrentUser.Phone ?? "Not set"; }
        }

        public string IconUrl
        {
            get { return App.UserController.CurrentUser.IconUrl; }
        }

        public ProfileViewModel()
        {
            Title = "Profile";
        }

        public void OnUserEditTapped(object sender, EventArgs args)
        {

        }
    }
}