using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using zhkh_mobile.Services;
using zhkh_mobile.Views;
using zhkh_mobile.Models;
using System.Net.Http;

namespace zhkh_mobile
{
    public partial class App : Application
    {
        static public HttpClient client;
        public static User user = new User();
        public static string ip = "http://192.168.0.59:14554/";
        public App()
        {
            InitializeComponent();

            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            client = new HttpClient(httpClientHandler);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

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
