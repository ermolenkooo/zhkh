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
    public class HistoryViewModel : BaseViewModel
    {
        private ObservableCollection<string> monthsList = new ObservableCollection<string>();
        public ObservableCollection<string> MonthsList
        {
            get { return monthsList; }
            set
            {
                if (monthsList != value)
                {
                    monthsList = value;
                    OnPropertyChanged("MonthsList");
                }
            }
        }

        private ObservableCollection<string> yearsList = new ObservableCollection<string>();
        public ObservableCollection<string> YearsList
        {
            get { return yearsList; }
            set
            {
                if (yearsList != value)
                {
                    yearsList = value;
                    OnPropertyChanged("YearsList");
                }
            }
        }

        private string selectedMonth;
        public string SelectedMonth
        {
            get { return selectedMonth; }
            set
            {
                if (selectedMonth != value)
                {
                    selectedMonth = value;
                    OnPropertyChanged("SelectedMonth");
                    GetDates();
                }
            }
        }

        private string selectedYear;
        public string SelectedYear
        {
            get { return selectedYear; }
            set
            {
                if (selectedYear != value)
                {
                    selectedYear = value;
                    OnPropertyChanged("SelectedYear");
                    GetDates();
                }
            }
        }

        private List<Service> allServices;

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
        ServiceService serviceService = new ServiceService();
        AddressService addressService = new AddressService();

        public HistoryViewModel()
        {
            GetData();
        }

        private async void GetData()
        {
            MonthsList.Add("январь");
            MonthsList.Add("февраль");
            MonthsList.Add("март");
            MonthsList.Add("апрель");
            MonthsList.Add("май");
            MonthsList.Add("июнь");
            MonthsList.Add("июль");
            MonthsList.Add("август");
            MonthsList.Add("сентябрь");
            MonthsList.Add("октябрь");
            MonthsList.Add("ноябрь");
            MonthsList.Add("декабрь");

            YearsList.Add("2020");
            YearsList.Add("2021");
            YearsList.Add("2022");
            YearsList.Add("2023");

            Address address = await addressService.GetAddressOfUser(App.user.Id);
            if (address !=  null)
            {
                allServices = await serviceService.GetPaidServices(address.Id);
                GetDates();
            }
        }

        private void GetDates()
        {
            Dates = new ObservableCollection<Date>();

            List<Service> services = allServices;
            if (SelectedMonth != null) 
                services = services.Where(x=>x.Month==SelectedMonth).ToList();
            if (selectedYear != null)
                services = services.Where(x => x.Year.ToString() == SelectedYear).ToList();

            List<string> strings = new List<string>();
            foreach (var s in services)
                if (!strings.Contains(s.Month + " " + s.Year))
                    strings.Add(s.Month + " " + s.Year);

            foreach (var str in strings)
            {
                var serv = services.Where(x => (x.Month + " " + x.Year) == str).ToList();
                ObservableCollection<Service> values = new ObservableCollection<Service>();
                foreach (var s in serv)
                    values.Add(s);
                Dates.Add(new Date { Name = str, Services = values });
            }
        }
    }
}
