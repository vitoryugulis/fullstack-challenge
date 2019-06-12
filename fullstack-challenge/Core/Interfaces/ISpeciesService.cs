using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Services.Models;

namespace Core.Interfaces
{
    public interface ISpeciesService
    {
        Task<SwapiSpecies> GetSpeciesByUrl(string speciesUrl);
        Task<List<Species>> GetAllSpecies(int pageNumber);
    }
}