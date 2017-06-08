using PetsInLove.Helpers;
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

        public ICommand LoginCommand =>
            loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommandAsync()));
        
        public LoginViewModel(INavigation nav)
        {
            azureService = DependencyService.Get<AzureService>();
            navigation = nav;

            Title = "Pets In Love - Login";
        }

        private async Task ExecuteLoginCommandAsync()
        {
            if(!(await LoginAsync()))
            {
                return;
            }
            else
            {
                await PushAsync<MainViewModel>();
            }

        }

        public Task<bool> LoginAsync()
        {
            if (Settings.isLoggedIn)
            {
                return Task.FromResult(true);
            }
            return azureService.LoginAsync();
        }
    }
}
