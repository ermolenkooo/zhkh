using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using zhkh_mobile.Models;
using zhkh_mobile.Services;
using zhkh_mobile.Views;

namespace zhkh_mobile.ViewModels
{
    public class AddAddressViewModel : BaseViewModel
    {
        public Command AddAddressCommand { get; }
        public Command BackCommand { get; }

        public INavigation Navigation { get; set; }
        AddressService addressService = new AddressService();

        private string city = "";
        private string street = "";
        private string house = "";
        private string flat = "";
        private bool show = false;

        public bool Show
        {
            get { return show; }
            set
            {
                show = value;
                OnPropertyChanged("Show");
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                if (city != "" && street != "" && house != "")
                    Show = true;
                else
                    Show = false;
                OnPropertyChanged("City");
            }
        }

        public string Street
        {
            get { return street; }
            set
            {
                street = value;
                if (city != "" && street != "" && house != "")
                    Show = true;
                else
                    Show = false;
                OnPropertyChanged("Street");
            }
        }

        public string House
        {
            get { return house; }
            set
            {
                house = value;
                if (city != "" && street != "" && house != "")
                    Show = true;
                else
                    Show = false;
                OnPropertyChanged("House");
            }
        }

        public string Flat
        {
            get { return flat; }
            set
            {
                flat = value;
                OnPropertyChanged("Flat");
            }
        }

        public AddAddressViewModel()
        {
            AddAddressCommand = new Command(OnAddAddressClicked);
            BackCommand = new Command(OnBackClicked);
        }

        private async void OnAddAddressClicked(object obj)
        {
            await addressService.AddAddress(new Address { City = city, Street = street, House = house, Flat = flat, Id_user = App.user.Id });
            await Navigation.PushAsync(new MainPage());
        }

        private async void OnBackClicked(object obj)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
