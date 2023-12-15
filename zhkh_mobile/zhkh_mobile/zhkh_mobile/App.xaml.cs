using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using zhkh_mobile.Services;
using zhkh_mobile.Views;
using zhkh_mobile.Models;

namespace zhkh_mobile
{
    public partial class App : Application
    {
        public static User user = new User();
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
