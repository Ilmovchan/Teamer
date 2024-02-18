using System;
using Rg.Plugins.Popup;
using Teamer.APP.Services;
using Teamer.APP.Views;
using Teamer.BL.Controllers;
using Teamer.DATA.Repository;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teamer.APP
{
    public partial class App : Application
    {

        public static DataContext Context { get; set; }
        public static UserController UserController { get; set; }
        public static TeamController TeamController { get; set; }
        public static TaskController TaskController { get; set; }

        public App()
        {
            InitializeComponent();

            Context = new DataContext();
            UserController = new UserController(Context);
            TeamController = new TeamController(Context);
            TaskController = new TaskController(Context);

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
