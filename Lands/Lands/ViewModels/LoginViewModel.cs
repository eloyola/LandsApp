namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.Views;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                SetValue(ref email, value);
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                SetValue(ref password, value);
            }
        }

        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                SetValue(ref isRunning, value);
            }
        }

        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                SetValue(ref isEnabled, value);
                //if (this.isEnabled != value)
                //{
                //    this.isEnabled = value;
                //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsEnabled)));
                //}
            }
        }

        public bool IsRemembered { get; set; }
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.isEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            this.Email = "enrique.loyola@gmail.com";
            this.Password = "1234";


            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "you must enter an email",
                    "Acept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "you must enter a password",
                    "Acept");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            
            if (this.Email != "enrique.loyola@gmail.com" || this.Password != "1234")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or password incorrect",
                    "Acept");
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;

            //await Application.Current.MainPage.DisplayAlert(
            //        "Ok",
            //        "Accepted",
            //        "Acept");
            //return;
            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }
        #endregion
    }
}
