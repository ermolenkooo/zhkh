using System;
using System.Collections.Generic;
using Xamarin.Forms;
using zhkh_mobile.ViewModels;
using zhkh_mobile.Views;

namespace zhkh_mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegPage), typeof(RegPage));
            Routing.RegisterRoute(nameof(HistoryPage), typeof(HistoryPage));
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
