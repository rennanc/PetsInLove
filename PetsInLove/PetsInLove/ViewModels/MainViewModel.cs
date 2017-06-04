using PetsInLove.Models;
using PetsInLove.Services;
using PetsInLove.ViewModels.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PetsInLove.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private readonly IPetsInLoveApiService _petsInLoveApiService;

        public ObservableCollection<Pet> Pets { get; }

        public Command AboutCommand { get; }

        public Command SearchCommand { get; }

        public Command<Pet> ShowCategoriaCommand { get; }

        public Command RefreshCommand { get; }

        public MainViewModel(IPetsInLoveApiService petsInLoveApiService)
        {
            _petsInLoveApiService = petsInLoveApiService;
            Pets = new ObservableCollection<Pet>();

            RefreshCommand = new Command(() => LoadPets(null)); // Sempre atualizar
            AboutCommand = new Command(ExecuteAboutCommand);
            SearchCommand = new Command(ExecuteSearchCommand);

            FilterPetDto filtroPetDto = new FilterPetDto();
            Pet pet = new Pet();
            pet.Name = "teste";
            Pets.Add(pet);

            LoadPets(null);

            Title = "Pets In Love";
        }

        private void ExecuteAboutCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private async void ExecuteSearchCommand(object obj)
        {
            await PushModalAsync<SearchViewModel>();
        }

        public void LoadPets(FilterPetDto filterPetDto)
        {


            var result = LoadAsync();

            //Pets.Clear();

            //foreach (var item in result)
            //{
            //    Pets.Add(item);
            //}
            //if (Pets != null && Pets.Count() > 0)
            //{
            //    setParams(Pets[countPage]);
            //}
        }

        public override async Task LoadAsync()
        {
            var pets = await _petsInLoveApiService.GetTagsAsync();

            //System.Diagnostics.Debug.WriteLine("FOUND {0} PETS", pets.Count);
            Pets.Clear();
            foreach (var pet in pets)
            {
                Pets.Add(pet);
            }

            OnPropertyChanged(nameof(Pets));
        }

        //private async void ExecuteShowCategoriaCommand(Pet pet)
        //{
        //    await PushAsync<CategoriaViewModel>(pet);
        //}
    }
}
