using PetsInLove.ViewModels;
using PetsInLove.Services;
using Xamarin.Forms;

namespace PetsInLove
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel ViewModel => BindingContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
            var petsInLoveApiService = DependencyService.Get<IPetsInLoveApiService>();
            BindingContext = new MainViewModel(petsInLoveApiService);
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ViewModel.ShowCategoriaCommand.Execute(e.SelectedItem);
            }
        }
    }
}
