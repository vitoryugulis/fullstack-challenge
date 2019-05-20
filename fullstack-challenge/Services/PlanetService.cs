using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using fullstack_challenge.Services.Interfaces;
using fullstack_challenge.Services.Models;

namespace fullstack_challenge.Services
{
    public class PlanetService : IPlanetService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<SwapiPlanet> GetPlanet(string planetUrl){
            var jsonResponse = await GetPlanetFromSwapi(planetUrl);
            var swapiPlanet = DeserializeSwapiPlanet(jsonResponse);
            return swapiPlanet;
        }

        private async Task<string> GetPlanetFromSwapi(string planetUrl){
            var response = await client.GetAsync(planetUrl);
            return await response.Content.ReadAsStringAsync();
        }

        private SwapiPlanet DeserializeSwapiPlanet(string swapiPlanetJson){
            SwapiPlanet deserializedSwapiPlanet = new SwapiPlanet();  
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(swapiPlanetJson));  
            DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedSwapiPlanet.GetType());  
            deserializedSwapiPlanet = ser.ReadObject(ms) as SwapiPlanet;  
            ms.Close();  
            return deserializedSwapiPlanet;
        }
    }
}