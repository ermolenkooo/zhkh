using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace zhkh_mobile.Models
{
    public class Service : INotifyPropertyChanged
    {
        private int id;
        private int id_address;
        private int id_category;
        private string company;
        private string month;
        private int year;
        private bool status;
        private double amount;
        private string account;
        private bool isSelect;
        private ServiceCategory category;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public int Id_address
        {
            get { return id_address; }
            set
            {
                id_address = value;
                OnPropertyChanged("Id_address");
            }
        }

        public int Id_category
        {
            get { return id_category; }
            set
            {
                id_category = value;
                OnPropertyChanged("Id_category");
            }
        }

        public string Company
        {
            get { return company; }
            set
            {
                company = value;
                OnPropertyChanged("Company");
            }
        }

        public string Month
        {
            get { return month; }
            set
            {
                month = value;
                OnPropertyChanged("Month");
            }
        }

        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }

        public bool Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public double Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public string Account
        {
            get { return account; }
            set
            {
                account = value;
                OnPropertyChanged("Account");
            }
        }

        public bool IsSelect
        {
            get { return isSelect; }
            set
            {
                isSelect = value;
                OnPropertyChanged("IsSelect");
            }
        }

        public ServiceCategory Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category");
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
