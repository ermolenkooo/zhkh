using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace zhkh_mobile.Models
{
    public class Address : INotifyPropertyChanged
    {
        private int id;
        private string city;
        private string street;
        private string house;
        private string flat;
        private int id_user;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        public string Street
        {
            get { return street; }
            set
            {
                street = value;
                OnPropertyChanged("Street");
            }
        }

        public string House
        {
            get { return house; }
            set
            {
                house = value;
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

        public int Id_user
        {
            get { return id_user; }
            set
            {
                id_user = value;
                OnPropertyChanged("Id_user");
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
