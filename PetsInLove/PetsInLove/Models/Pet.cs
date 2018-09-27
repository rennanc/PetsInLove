using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using PetsInLove.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PetsInLove.Models
{
    [DataTable("Pets")]
    public class Pet : INotifyPropertyChanged
    {
        [Version]
        public string AzureVersion { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Genre")]
        public Genre Genre { get; set; }
        //public Species Species { get; set; }
        [JsonProperty("Breed")]
        public string Breed { get; set; }
        [JsonProperty("Photo")]
        public string Photo { get; set; }
        [JsonProperty("Detail")]
        public string Detail { get; set; }



        //address
        [JsonProperty("City")]
        public string City { get; set; }
        [JsonProperty("Country")]
        public string Country { get; set; }
        // [JsonProperty("Neighboorhood")]
        //public string Neighboorhood { get; set; }

        //Owner
        [JsonProperty("Ownername")]
        public string OwnerName { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Phone")]
        public string Phone { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		// public Owner Owner { get; set; }

		public Pet()
		{
			this.AzureVersion = "AAAAAAAAB90=";
		}
    }
}
