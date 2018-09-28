using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsInLove.Services;

namespace PetsInLove.ViewModels
{
    class AboutViewModel : BaseViewModel
    {

        private readonly IPetsInLoveApiService _petsInLoveApiService;

        public AboutViewModel(IPetsInLoveApiService petsInLoveApiService)
        {
            _petsInLoveApiService = petsInLoveApiService;
        }

        public AboutViewModel()
        {

        }


    }
}
