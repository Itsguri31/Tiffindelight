using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tiffindelight.Models;
using Tiffindelight.Services;
//using Tiffindelight.Services;

namespace Tiffindelight.ViewModels
{
    public class LoginViewModel: ObservableRecipient
    {
        public string Email { get; set; }
        public string Password { get; set; }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        protected static FirebaseAuthentication Authentication => FirebaseAuthentication.Instance;
        public IAsyncRelayCommand SignInCommand { get; }
        public IAsyncRelayCommand SignUpCommand { get; }

        public LoginViewModel()
        {
            SignInCommand = new AsyncRelayCommand(SignIn);
            SignUpCommand = new AsyncRelayCommand<Activity>(SignUp);
        }

        private async Task SignIn()
        {
            var (success, message) = await Authentication.SignInAsync(Email, Password);
            
            
            Message = message;

            if (success)
            {
                await Shell.Current.GoToAsync($"///{nameof(Views.HomePage)}");
                //await Shell.Current.GoToAsync("//HomePage");
            }
        }

        private async Task SignUp(Activity activity)
        {
            var (success, message) = await Authentication.SignUpAsync(Email, Password);
            Message = message;

            if (success)
            {
                await Shell.Current.GoToAsync($"///{nameof(Views.HomePage)}");
            }

            //await Shell.Current.GoToAsync($"///{nameof(Views.ActivityDetailsView)}?id={activity.Id}");
        }

    }
}
