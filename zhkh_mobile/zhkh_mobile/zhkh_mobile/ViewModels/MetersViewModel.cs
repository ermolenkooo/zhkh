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
    public class MetersViewModel : BaseViewModel
    {
        public Command BackCommand { get; }
        public Command SendCommand { get; }

        private ObservableCollection<Meter> meters;
        public ObservableCollection<Meter> Meters
        {
            get { return meters; }
            set
            {
                if (meters != value)
                {
                    meters = value;
                    OnPropertyChanged("Meters");
                }
            }
        }

        public INavigation Navigation { get; set; }
        MeterService meterService = new MeterService();

        public MetersViewModel(int id)
        {
            BackCommand = new Command(OnBackClicked);
            SendCommand = new Command(OnSendClicked);
            GetData(id);
        }

        private async void GetData(int id)
        {
            Meters = new ObservableCollection<Meter>();
            var list = await meterService.GetMetersOfAddress(id);

            foreach (var m in list)
            {
                m.TextDate = m.Date.ToString("d");
                m.TextReading = m.Reading.ToString() + " " + m.Category.Unit;
                Meters.Add(m);
            }
        }

        private async void OnBackClicked(object obj)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void OnSendClicked(object obj)
        {
            foreach (var m in meters)
                if (m.NewReading != null)
                    meterService.UpdateReading(m.Id, (int)m.NewReading);

            await Navigation.PushAsync(new MainPage());
        }
    }
}
