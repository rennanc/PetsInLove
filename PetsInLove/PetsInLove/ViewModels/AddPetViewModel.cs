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
        public Command RegisterCommand { get; }
        public Pet Pet { get; set; }

        public AddPetViewModel(IPetsInLoveApiService petsInLoveApiService)
        {
            _petsInLoveApiService = petsInLoveApiService;
			this.Pet = new Pet();
			RegisterCommand = new Command(ExecuteRegisterCommand);
        }

        public AddPetViewModel()
        {
        }

        private async void ExecuteRegisterCommand(object obj)
        {
			await _petsInLoveApiService.InsertItemAsync(this.Pet);
        }
    }
}
