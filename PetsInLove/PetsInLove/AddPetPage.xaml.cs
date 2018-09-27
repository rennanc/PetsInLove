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
    public partial class AddPetPage : ContentPage
    {

        private AddPetViewModel ViewModel => BindingContext as AddPetViewModel;
        public AddPetPage()
        {
            InitializeComponent();
        }
    }
}