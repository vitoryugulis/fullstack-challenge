using AutoMapper;
using Core.Interfaces;
using Core.Entities;
using Core.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services {
    public class PeopleService : IPeopleService{

        string swapiUrl = "https://swapi.co/api/";
        private static readonly HttpClient client = new HttpClient();
        private readonly IPlanetService planetService;
        private readonly ISpeciesService speciesService;

        public PeopleService(IPlanetService planetService, ISpeciesService speciesService)
        {
            this.planetService = planetService;
            this.speciesService = speciesService;
        }

        public async Task<List<Person>> GetPeople(int pageNumber){
            var response = await GetPeopleFromSwapi(pageNumber);
            var personList = await TransformSwapiPeopleToPersonList(response);
            return personList;
        }

        private async Task<string> GetPeopleFromSwapi(int pageNumber){
            string requestUrl = $"{swapiUrl}people/?page={pageNumber}";
            if(pageNumber == 0){
                requestUrl = $"{swapiUrl}people/";
            }
            var response = await client.GetAsync(requestUrl);
            return await response.Content.ReadAsStringAsync();
        }

        private async Task<List<Person>> TransformSwapiPeopleToPersonList(string swapiPeopleResult){
            var deserializedSwapiPeopleResponse = JsonConvert.DeserializeObject<SwapiPeopleResponse>(swapiPeopleResult);

            var peopleList = new List<Person>();
            foreach (var swapiPerson in deserializedSwapiPeopleResponse.results){
                var person = Mapper.Map<Person>(swapiPerson);
                person.Homeworld = await GetPlanetName(person.Homeworld);
                person.Species = await GetSpeciesNameList(person.Species);
                peopleList.Add(person);
            }

            return peopleList;
        }

        private async Task<string> GetPlanetName(string planetUrl){
            var swapiPlanet = await planetService.GetPlanet(planetUrl);
            return swapiPlanet.name;
        }

        private async Task<List<string>> GetSpeciesNameList(List<string> personSpeciesUrls){
            var speciesNameList = new List<string>();
            foreach(var speciesUrl in personSpeciesUrls){
                var swapiSpecies = await speciesService.GetSpecies(speciesUrl);
                speciesNameList.Add(swapiSpecies.name);
            }
            return speciesNameList;
        }
    }
}