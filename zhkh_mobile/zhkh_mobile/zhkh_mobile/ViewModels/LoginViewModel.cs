using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using zhkh_mobile.Models;
using zhkh_mobile.Services;
using zhkh_mobile.Views;

namespace zhkh_mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegCommand { get; }

        private string phone;
        private string password;
        private string warning;
        public INavigation Navigation { get; set; }
        UserService userService = new UserService();

        public LoginViewModel()
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
            var user = await userService.Login(new User { Phone = Phone, Password = Password });
            if (user == null)
                Warning = "Неверный логин и/или пароль!";
            else
            {
                App.user = user;
                await Navigation.PushAsync(new MainPage());
            }
            //await Navigation.PushAsync(new ProfilPage(user, user));
        }

        private async void OnRegClicked(object obj)
        {
            await Navigation.PushAsync(new RegPage());
            //await Shell.Current.GoToAsync($"//{nameof(RegPage)}");
            //Navigation.PushAsync(new RegPage());
        }

        //private async void OnLoginClicked(object obj)
        //{
        //    // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        //    await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        //}
    }
}
