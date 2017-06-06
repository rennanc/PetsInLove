using PetsInLove.ViewModels;
using PetsInLove.Services;
using Xamarin.Forms;
using System;
using PetsInLove.Models.Enums;
using System.Linq;
using PetsInLove.ViewModels.Dto;

namespace PetsInLove
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel ViewModel => BindingContext as MainViewModel;

        public Command OpenFilter { get; }

        public MainPage()
        {
            InitializeComponent();
            var petsInLoveApiService = DependencyService.Get<IPetsInLoveApiService>();
            BindingContext = new MainViewModel(petsInLoveApiService);
            
            OpenPickerSpecies();
            OpenPickerGenre();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ViewModel.ShowCategoriaCommand.Execute(e.SelectedItem);
            }
        }

        private void ExecuteOpenFilterCommand(object sender, EventArgs e)
        {
            if (pickerSpecies.IsVisible)
            {

                txtBreed.IsVisible = false;
                pickerGenre.IsVisible = false;
                pickerSpecies.IsVisible = false;

                FilterPetDto filterPetDto = new FilterPetDto();
                filterPetDto.Breed = txtBreed.Text;
                //filterPetDto.Genre = (Genre)Enum.Parse(typeof(Genre), pickerGenre.Items[pickerGenre.SelectedIndex + 1]);
                //filterPetDto.Species = (Species)Enum.Parse(typeof(Species), pickerSpecies.Items[pickerSpecies.SelectedIndex]);

                ViewModel.LoadPets(filterPetDto);
            }
            else
            {
                txtBreed.IsVisible = true;
                pickerGenre.IsVisible = true;
                pickerSpecies.IsVisible = true;
            }
        }


        private void OpenPickerSpecies()
        {
            var values = Enum.GetValues(typeof(Species)).Cast<Species>();

            pickerSpecies.Title = "Escolha a Espécie";
            pickerSpecies.VerticalOptions = LayoutOptions.CenterAndExpand;
            foreach (Species specie in values)
            {
                pickerSpecies.Items.Add(specie.ToString());
            }
            pickerSpecies.Focus();
        }

        private void OpenPickerGenre()
        {

            var values = Enum.GetValues(typeof(Genre)).Cast<Genre>();

            pickerGenre.Title = "Escolha a Raça";
            pickerGenre.VerticalOptions = LayoutOptions.CenterAndExpand;
            foreach (Genre value in values)
            {
                pickerGenre.Items.Add(value.ToString());
            }
            pickerGenre.Focus();
        }
    }
}
