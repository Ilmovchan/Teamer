using Teamer.APP.Views;
using Teamer.BL.Controllers;
using Teamer.DATA.Repository;
using Xamarin.Forms;

namespace Teamer.APP.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        private string _loginName;
        public string LoginName 
        {
            get { return _loginName; }  
            set { 
                _loginName = value;
                OnPropertyChanged(nameof(LoginName));
            }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            App.UserController.SetCurrentUser(LoginName);
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}
