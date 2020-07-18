namespace LandsApplication
{
    using LandsApplication.Views;
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            this.MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
