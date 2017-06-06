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
    public class SearchViewModel : BaseViewModel
    {
        private readonly IPetsInLoveApiService _petsInLoveApiService;
        private FilterPetDto _filterPetDto;
        public ObservableCollection<Pet> SearchResults { get; }

        public Command SearchCommand { get; }

        public SearchViewModel(IPetsInLoveApiService petsInLoveApiService)
        {
            _petsInLoveApiService = petsInLoveApiService;
            SearchCommand = new Command(ExecuteSearchCommand);

        }

        public SearchViewModel()
        {
        }

        private async void ExecuteSearchCommand()
        {

            var searchResults = await _petsInLoveApiService.GetContentsByFilterAsync(_filterPetDto);

            SearchResults.Clear();
            if (searchResults == null)
            {
                await DisplayAlert("Pets In Love", "Nenhum resultado encontrado.", "Ok");
                return;
            }

            foreach (var searchResult in searchResults)
            {
                SearchResults.Add(searchResult);
            }
        }

    }
}
