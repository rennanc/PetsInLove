using PetsInLove.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsInLove.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private readonly IPetsInLoveApiService _petsInLoveApiService;

        public SearchViewModel(IPetsInLoveApiService petsInLoveApiService)
        {
            _petsInLoveApiService = petsInLoveApiService;

           
        }

    }
}
