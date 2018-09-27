using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Collections.ObjectModel;
using PetsInLove.Models;
using Xamarin.Forms;
using PetsInLove.ViewModels.Dto;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;

[assembly: Dependency(typeof(PetsInLove.Services.PetsInLoveApiService))]
namespace PetsInLove.Services
{
    public class PetsInLoveApiService : IPetsInLoveApiService
    {
        IMobileServiceClient _client;
        IMobileServiceTable<Pet> Table;

        private const string BaseUrl = "http://petsinlove.azurewebsites.net/Tables/";

        public async Task<List<Pet>> GetTagsAsync()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{BaseUrl}Pets").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Pet>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }

        public PetsInLoveApiService()
        {
            //string MyAppServiceURL = "http://petsinlove.azurewebsites.net/";
            //_client = new MobileServiceClient(MyAppServiceURL);
            //Table = _client.GetTable<Pet>();
        }

        public async Task<List<Pet>> GetTable()
        {
            return await Table.ToListAsync();
        }

        public async Task InsertItemAsync(Pet pet)
        {
			await Table.InsertAsync(pet);//.ConfigureAwait(false);
        }

        public async Task DeleteItemAsync(Pet pet)
        {
            await Table.DeleteAsync(pet).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Pet>> GetPets(FilterPetDto filterPetDto)
        {
            IEnumerable<Pet> Items = await GetTable();

            if (filterPetDto != null)
            {
                Items = from p in Items
                        where p.Breed.ToLower().Contains(filterPetDto.Breed.ToLower())
                        select p;
            }

            return Items.ToList();
        }

        public Task<List<Pet>> GetContentsByFilterAsync(FilterPetDto filterPetDto)
        {
            throw new NotImplementedException();
        }

        //public async Task SyncAsync()
        //{
        //    ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;
        //    try
        //    {
        //        await _client.SyncContext.PushAsync();

        //        await _table.PullAsync("allContacts", _table.CreateQuery());
        //    }
        //    catch (MobileServicePushFailedException pushEx)
        //    {
        //        if (pushEx.PushResult != null)
        //            syncErrors = pushEx.PushResult.Errors;
        //    }
        //}
    }
}
