using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace zhkh_mobile.Models
{
    public class Meter : INotifyPropertyChanged
    {
        private int id;
        private int id_address;
        private string number;
        private int id_category;
        private DateTime date;
        private int? reading;
        private MeterCategory category;
        private int? newReading;
        private string textDate;
        private string textReading;

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

        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public int? Reading
        {
            get { return reading; }
            set
            {
                reading = value;
                OnPropertyChanged("Reading");
            }
        }

        public int? NewReading
        {
            get { return newReading; }
            set
            {
                newReading = value;
                OnPropertyChanged("NewReading");
            }
        }

        public MeterCategory Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category");
            }
        }

        public string TextDate
        {
            get { return textDate; }
            set
            {
                textDate = value;
                OnPropertyChanged("TextDate");
            }
        }

        public string TextReading
        {
            get { return textReading; }
            set
            {
                textReading = value;
                OnPropertyChanged("TextReading");
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
