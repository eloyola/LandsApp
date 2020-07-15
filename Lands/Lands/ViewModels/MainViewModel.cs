namespace Lands.ViewModels
{
    using Lands.Views;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MainViewModel
    {
        #region Viewmodels
        public LoginViewModel Login { get; set; }

        public LandsViewModel Lands { get; set; } 
        #endregion

        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }


        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }
            return instance;
        } 
        #endregion
    }
}
