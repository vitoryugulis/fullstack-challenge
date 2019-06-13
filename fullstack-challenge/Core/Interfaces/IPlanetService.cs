using System.Threading.Tasks;
using Core.Services.Models;

namespace Core.Interfaces
{
    public interface IPlanetService
    {
         Task<SwapiPlanet> GetPlanet(string planetUrl);
    }
}