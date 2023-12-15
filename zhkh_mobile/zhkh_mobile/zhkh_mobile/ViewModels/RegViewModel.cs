using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using zhkh_mobile.Models;
using zhkh_mobile.Services;
using zhkh_mobile.Views;

namespace zhkh_mobile.ViewModels
{
    public class RegViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegCommand { get; }

        private string phone;
        private string password;
        private string password2;
        private string warning;

        public INavigation Navigation { get; set; }
        UserService userService = new UserService();

        public RegViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegCommand = new Command(OnRegClicked);
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                if (phone != value)
                {
                    phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string Password2
        {
            get { return password2; }
            set
            {
                if (password2 != value)
                {
                    password2 = value;
                    OnPropertyChanged("Password2");
                }
            }
        }

        public string Warning
        {
            get { return warning; }
            set
            {
                if (warning != value)
                {
                    warning = value;
                    OnPropertyChanged("Warning");
                }
            }
        }

        private async void OnLoginClicked(object obj)
        {
            await Navigation.PushAsync(new LoginPage());
            //await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        private async void OnRegClicked(object obj)
        {
            if (Phone == null || Password == null)
            {
                Warning = "Заполните все поля!";
                return;
            }
            if (Password != Password2)
            {
                Warning = "Пароли не совпадают!";
                return;
            }
            var user = await userService.Reg(new User { Phone = Phone, Password = Password });
            if (user == null)
                Warning = "На этот номер телефона уже зарегистрирован аккаунт!";
            else
            {
                App.user = user;
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}
