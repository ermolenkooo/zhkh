using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using zhkh_mobile.Models;
using zhkh_mobile.ViewModels;

namespace zhkh_mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAddressPage : ContentPage
    {
        public AddAddressPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new AddAddressViewModel() { Navigation = this.Navigation };
        }
    }
}