﻿using System;
using Teamer.APP.Services;
using Teamer.APP.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teamer.APP
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

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
