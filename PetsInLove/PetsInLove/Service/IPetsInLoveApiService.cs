using PetsInLove.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetsInLove.ViewModels.Dto;

namespace PetsInLove.Services
{
    public interface IPetsInLoveApiService
    {
        Task<List<Pet>> GetTable();
        Task DeleteItemAsync(Pet pet);
        Task InsertItemAsync(Pet pet);
        Task<IEnumerable<Pet>> GetPets(FilterPetDto filterPetDto);
        Task<List<Pet>> GetTagsAsync();
        Task<List<Pet>> GetContentsByFilterAsync(FilterPetDto filterPetDto);
    }
}
