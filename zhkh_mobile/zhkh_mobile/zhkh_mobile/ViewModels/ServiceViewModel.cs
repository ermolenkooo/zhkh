using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using zhkh_mobile.Models;
using zhkh_mobile.Services;
using zhkh_mobile.Views;

namespace zhkh_mobile.ViewModels
{
    public class ServiceViewModel : BaseViewModel
    {
        public Command BackCommand { get; }

        public INavigation Navigation { get; set; }
        
        private Service service;
        private string period = "";
        private string amount = "";

        public Service Service
        {
            get { return service; }
            set
            {
                service = value;
                OnPropertyChanged("Service");
            }
        }

        public string Period
        {
            get { return period; }
            set
            {
                period = value;
                OnPropertyChanged("Period");
            }
        }

        public string Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public ServiceViewModel(Service service)
        {
            Service = service;
            Period = Service.Month + " " + Service.Year;
            Amount = Service.Amount + "₽";
            BackCommand = new Command(OnBackClicked);
        }

        private async void OnBackClicked(object obj)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
