using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Services.Models;
using Newtonsoft.Json;

namespace Core.Services
{
    public class PlanetService : IPlanetService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<SwapiPlanet> GetPlanet(string planetUrl){
            var jsonResponse = await GetPlanetFromSwapi(planetUrl);
            var swapiPlanet = JsonConvert.DeserializeObject<SwapiPlanet>(jsonResponse);
            return swapiPlanet;
        }

        private async Task<string> GetPlanetFromSwapi(string planetUrl){
            var response = await client.GetAsync(planetUrl);
            return await response.Content.ReadAsStringAsync();
        }
    }
}