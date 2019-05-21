using System.Threading.Tasks;
using Core.Services.Models;

namespace Core.Interfaces
{
    public interface ISpeciesService
    {
        Task<SwapiSpecies> GetSpecies(string speciesUrl);
    }
}