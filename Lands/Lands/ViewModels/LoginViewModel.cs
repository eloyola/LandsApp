namespace Lands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;

    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsRunning { get; set; }

        public bool IsRemembered { get; set; }

        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            this.IsRemembered = true;
        }
    }
}
