using Microsoft.WindowsAzure.MobileServices;
using PetsInLove.Helpers;
using PetsInLove.Models.Enums;
using PetsInLove.Service;
using PetsInLove.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetsInLove.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        AzureService azureService;
        INavigation navigation;

        ICommand loginCommand;
        ICommand loginGoogleCommand;

        public ICommand LoginCommand =>
            loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommandAsync(MobileServiceAuthenticationProvider.Facebook)));

        public ICommand LoginGoogleCommand =>
            loginGoogleCommand ?? (loginGoogleCommand = new Command(async () => await ExecuteLoginCommandAsync(MobileServiceAuthenticationProvider.Google)));

        public LoginViewModel(INavigation nav)
        {
            azureService = DependencyService.Get<AzureService>();
            navigation = nav;
            Title = "Pets In Love - Login";
        }

        private async Task ExecuteLoginCommandAsync(MobileServiceAuthenticationProvider mobileServiceAuthenticationProvider)
        {
            if(!(await LoginAsync(mobileServiceAuthenticationProvider)))
            {
                return;
            }
            else
            {
                await PushAsync<MainViewModel>();
            }

        }

        public Task<bool> LoginAsync(MobileServiceAuthenticationProvider mobileServiceAuthenticationProvider)
        {
            if (Settings.isLoggedIn)
            {
                return Task.FromResult(true);
            }
            return azureService.LoginAsync(mobileServiceAuthenticationProvider);
        }
    }
}
