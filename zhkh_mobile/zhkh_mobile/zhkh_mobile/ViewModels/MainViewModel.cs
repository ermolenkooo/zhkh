using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using zhkh_mobile.Models;
using zhkh_mobile.Services;
using zhkh_mobile.Views;
using static Xamarin.Essentials.Permissions;

namespace zhkh_mobile.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public Command AddAddressCommand { get; }
        public Command ServiceCommand { get; }
        public Command MetersCommand { get; }
        public Command PayCommand { get; }
        public Command SelectingCommand { get; }

        private Address address;
        public Address Address
        {
            get { return address; }
            set
            {
                if (address != value)
                {
                    address = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        private bool hasAddress;
        public bool HasAddress
        {
            get { return hasAddress; }
            set
            {
                if (hasAddress != value)
                {
                    hasAddress = value;
                    OnPropertyChanged("HasAddress");
                }
            }
        }

        private bool show = false;
        public bool Show
        {
            get { return show; }
            set
            {
                if (show != value)
                {
                    show = value;
                    OnPropertyChanged("Show");
                }
            }
        }

        private string textButton;
        public string TextButton
        {
            get { return textButton; }
            set
            {
                if (textButton != value)
                {
                    textButton = value;
                    OnPropertyChanged("TextButton");
                }
            }
        }

        private ObservableCollection<Date> dates;
        public ObservableCollection<Date> Dates
        {
            get { return dates; }
            set
            {
                if (dates != value)
                {
                    dates = value;
                    OnPropertyChanged("Dates");
                }
            }
        }

        public INavigation Navigation { get; set; }
        AddressService addressService = new AddressService();
        ServiceService serviceService = new ServiceService();

        public MainViewModel()
        {
            AddAddressCommand = new Command(OnAddAddressClicked);
            MetersCommand = new Command(OnMetersClicked);
            PayCommand = new Command(OnPayClicked);
            SelectingCommand = new Command(OnSelectingClicked);
            ServiceCommand = new Command(OnServiceClicked);
            GetData();
        }

        private async void GetData()
        {
            Address = await addressService.GetAddressOfUser(App.user.Id);

            if (address == null)
                HasAddress = false;
            else
            {
                HasAddress = true;
                var services = await serviceService.GetUnpaidServices(Address.Id);
                Dates = new ObservableCollection<Date>();

                List<string> strings = new List<string>();
                foreach (var s in services)
                    if (!strings.Contains(s.Month + " " + s.Year))
                        strings.Add(s.Month + " " + s.Year);

                foreach (var str in strings)
                {
                    var serv = services.Where(x => (x.Month + " " + x.Year) == str).ToList();
                    ObservableCollection<Service> values = new ObservableCollection<Service>();
                    foreach(var s in serv)
                        values.Add(s);
                    Dates.Add(new Date { Name = str, Services = values });
                }
            }
        }

        private async void OnAddAddressClicked(object obj)
        {
            await Navigation.PushAsync(new AddAddressPage());
        }

        private async void OnMetersClicked(object obj)
        {

        }

        private async void OnPayClicked(object obj)
        {
            List<Service> selected = new List<Service>();
            foreach (var d in Dates)
                foreach (var s in d.Services)
                    if (s.IsSelect)
                        selected.Add(s);

            await Navigation.PushAsync(new PayPage(selected));
        }

        private async void OnServiceClicked(object obj)
        {
            for (int i = 0; i < Dates.Count; i++)
                for (int j = 0; j < Dates[i].Services.Count; j++)
                    if (Dates[i].Services[j].Id == (int)obj)
                    {
                        await Navigation.PushAsync(new ServicePage(Dates[i].Services[j]));
                        return;
                    }
        }

        private void OnSelectingClicked(object obj)
        {
            for (int i = 0; i < Dates.Count; i++)
                for (int j = 0; j < Dates[i].Services.Count; j++)
                    if (Dates[i].Services[j].Id == (int)obj)
                    {
                        Dates[i].Services[j].IsSelect = !Dates[i].Services[j].IsSelect;
                        break;
                    }

            double sum = 0;
            foreach (var d in Dates) 
                foreach (var s in d.Services) 
                    if (s.IsSelect)
                        sum += s.Amount;

            TextButton = "Оплатить: " + sum + "₽";
            if (sum != 0)
                Show = true;
            else 
                Show = false;
        }
    }

    public class Date : INotifyPropertyChanged
    {
        private ObservableCollection<Service> services;
        private string name;

        public ObservableCollection<Service> Services
        {
            get { return services; }
            set
            {
                services = value;
                OnPropertyChanged("Services");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
