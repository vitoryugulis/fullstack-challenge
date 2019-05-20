using System.Threading.Tasks;
using fullstack_challenge.Services.Models;

namespace fullstack_challenge.Services.Interfaces
{
    public interface IPlanetService
    {
         Task<SwapiPlanet> GetPlanet(string planetUrl);
    }
}