using PetsInLove.Models;
using PetsInLove.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetsInLove.ViewModels
{
    public class AddPetViewModel : BaseViewModel
    {

        private readonly IPetsInLoveApiService _petsInLoveApiService;
        Command RegisterCommand;
        public Pet _pet;

        public AddPetViewModel(IPetsInLoveApiService petsInLoveApiService)
        {
            _petsInLoveApiService = petsInLoveApiService;
            RegisterCommand = new Command(ExecuteRegisterCommand);
        }

        public AddPetViewModel()
        {
        }

        private async void ExecuteRegisterCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
