using System.Threading.Tasks;
using Core.Services.Models;

namespace Core.Interfaces
{
    public interface ISpeciesService
    {
        Task<SwapiSpecies> GetSpeciesByUrl(string speciesUrl);
        Task<PaginatedSpecies> GetAllSpecies(int pageNumber);
        Task<PaginatedSpecies> GetSpeciesByName(string name, int page);
    }
}