using Rg.Plugins.Popup.Services;
using System;
using System.Reflection;
using Teamer.APP.Views;
using Xamarin.Forms;

namespace Teamer.APP.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {

        public Command UserNameEditTappedCommand { get; }
        public Command EmailEditTappedCommand { get; }
        public Command PhoneEditTappedCommand { get; }
        public Command AcceptButtonCommand {  get; }
        public Command ChangeProfileIconCommand { get; }

        private bool _isAcceptButtonVisible;
        public bool IsAcceptButtonVisible
        {
            get { return _isAcceptButtonVisible; }
            set
            {
                _isAcceptButtonVisible = value;
                OnPropertyChanged(nameof(IsAcceptButtonVisible));
            }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        private string _userIconUrl = "default_profile_icon.png";

        public string UserIconUrl 
        {
            get { return _userIconUrl; }
            set { 
                _userIconUrl = value;
                OnPropertyChanged(nameof(UserIconUrl));
            }
        }

        public ProfileViewModel()
        {
            Title = "Profile";

            UserName = App.UserController.CurrentUser.Name;
            Email = App.UserController.CurrentUser.Email;
            Phone = App.UserController.CurrentUser.Phone;

            UserNameEditTappedCommand = new Command(OnUserNameEditTapped);
            EmailEditTappedCommand = new Command(OnEmailEditTapped);
            PhoneEditTappedCommand = new Command(OnPhoneEditTapped);

            AcceptButtonCommand = new Command(OnAcceptButtonTapped);
            ChangeProfileIconCommand = new Command(OnChangeProfileIconTapped);
        }

        private void OnAcceptButtonTapped()
        {
            App.UserController.EditUser(UserName, Email, Phone);
            RefreshPage();
            UpdateAcceptButtonVisibility();
        }

        private async void OnUserNameEditTapped()
        {
            string name = await App.Current.MainPage.DisplayPromptAsync("Name: ", "Enter new name: ", "Edit", "Cancel");
            if (!string.IsNullOrEmpty(name))
            {
                UserName = name;
                UpdateAcceptButtonVisibility();
            }
        }

        private async void OnEmailEditTapped()
        {
            string email = await App.Current.MainPage.DisplayPromptAsync("Email: ", "Enter new email: ", "Edit", "Cancel");
            if (!string.IsNullOrEmpty(email))
            {
                Email = email;
                UpdateAcceptButtonVisibility();
            }
        }

        private async void OnPhoneEditTapped()
        {
            string phone = await App.Current.MainPage.DisplayPromptAsync("Phone: ", "Enter new phone: ", "Edit", "Cancel");
            if (!string.IsNullOrEmpty(phone))
            {
                Phone = phone;
                UpdateAcceptButtonVisibility();
            }
        }

        private void RefreshPage()
        {
            OnPropertyChanged(null);
        }

        private void UpdateAcceptButtonVisibility()
        {
            IsAcceptButtonVisible = !IsAcceptButtonVisible;
        }

        private void OnChangeProfileIconTapped()
        {

        }
    }
}