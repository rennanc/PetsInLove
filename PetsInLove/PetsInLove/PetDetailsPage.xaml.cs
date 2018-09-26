using PetsInLove.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetsInLove
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetDetailsPage : ContentPage
    {

        private PetDetailsViewModel ViewModel => BindingContext as PetDetailsViewModel;

        public PetDetailsPage()
        {
            InitializeComponent();
        }
    }
}