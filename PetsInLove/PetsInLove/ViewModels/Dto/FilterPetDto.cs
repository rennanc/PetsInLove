using PetsInLove.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsInLove.ViewModels.Dto
{
    public class FilterPetDto
    {
        public Genre Genre { get; set; }
        public string Breed { get; set; }
        public Species Species { get; set; }
    }
}
