using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using zhkh_mobile.Models;
using zhkh_mobile.Services;
using zhkh_mobile.Views;

namespace zhkh_mobile.ViewModels
{
    public class PayViewModel : BaseViewModel
    {
        public Command PayCommand { get; }
        public Command BackCommand { get; }

        public INavigation Navigation { get; set; }
        ServiceService serviceService = new ServiceService();

        private List<Service> services;
        private string number = "";
        private string date = "";
        private string textButton = "";
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

        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                if (number != "" && date != "")
                    Show = true;
                else
                    Show = false;
                OnPropertyChanged("Number");
            }
        }

        public string Date
        {
            get { return date; }
            set
            {
                date = value;
                if (number != "" && date != "")
                    Show = true;
                else
                    Show = false;
                OnPropertyChanged("Date");
            }
        }

        public string TextButton
        {
            get { return textButton; }
            set
            {
                textButton = value;
                OnPropertyChanged("TextButton");
            }
        }

        public PayViewModel(List<Service> services)
        {
            this.services = services;

            double sum = 0;
            foreach (var s in services)
                sum += s.Amount;
            TextButton = "Оплатить: " + sum + "₽";

            PayCommand = new Command(OnPayClicked);
            BackCommand = new Command(OnBackClicked);
        }

        private async void OnPayClicked(object obj)
        {
            foreach (var s in services)
                await serviceService.UpdateStatusOfService(s.Id);
            await Navigation.PushAsync(new MainPage());
        }

        private async void OnBackClicked(object obj)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
