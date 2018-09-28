using PetsInLove.Models;
using PetsInLove.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PetsInLove.ViewModels
{
    public class PetDetailsViewModel : BaseViewModel
    {
        private readonly IPetsInLoveApiService _petsInLoveApiService;

        public Command CallCommand { get; }
        public Command EmailCommand { get; }
        public Command OpenMapCommand { get; }

        public Pet Pet { get; set; }

        public PetDetailsViewModel(IPetsInLoveApiService petsInLoveApiService, Pet Pet)
        {
            this.Pet = Pet;
            CallCommand = new Command(ExecuteCallCommand);
            EmailCommand = new Command(ExecuteEmailCommand);
            OpenMapCommand = new Command(ExecuteOpenMapCommand);
        }

        public PetDetailsViewModel()
        {

        }

        private async void ExecuteEmailCommand(object obj)
        {
            var message = new EmailMessage
            {
                Subject = "[PetsInLove]",
                Body = "Olá, eu vi seu anuncio na PetsInLove",
                To = new List<string> { this.Pet.Email },
            };
            await Email.ComposeAsync(message);

        }

        private async void ExecuteCallCommand(object obj)
        {
            PhoneDialer.Open(this.Pet.Phone);
        }

        private async void ExecuteOpenMapCommand(object obj)
        {
            var placemark = new Placemark
            {
                CountryName = this.Pet.Country,
                AdminArea = this.Pet.City,
                Thoroughfare = "PetShop",
                Locality = this.Pet.City
            };
            var options = new MapsLaunchOptions { Name = this.Pet.Name };

            await Maps.OpenAsync(placemark, options);
        }
    }
}
