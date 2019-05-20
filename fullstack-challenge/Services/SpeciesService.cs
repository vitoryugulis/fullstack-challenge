using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using fullstack_challenge.Services.Interfaces;
using fullstack_challenge.Services.Models;
using Newtonsoft.Json;

namespace fullstack_challenge.Services
{
    public class SpeciesService : ISpeciesService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<SwapiSpecies> GetSpecies(string speciesUrl){
            var jsonResponse = await GetSpeciesFromSwapi(speciesUrl);
            var swapiSpecies = JsonConvert.DeserializeObject<SwapiSpecies>(jsonResponse);
            return swapiSpecies;
        }

        private async Task<string> GetSpeciesFromSwapi(string speciesUrl){
            var response = await client.GetAsync(speciesUrl);
            return await response.Content.ReadAsStringAsync();
        }
    }
}