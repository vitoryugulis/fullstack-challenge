using AutoMapper;
using fullstack_challenge.Entities;
using fullstack_challenge.Services.Interfaces;
using fullstack_challenge.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace fullstack_challenge.Services {
    public class PeopleService : IPeopleService{

        string swapiUrl = "https://swapi.co/api/";
        private static readonly HttpClient client = new HttpClient();
        private readonly IPlanetService planetService;

        public PeopleService(IPlanetService planetService)
        {
            this.planetService = planetService;
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
                var swapiPlanet = await planetService.GetPlanet(person.Homeworld);
                person.Homeworld = swapiPlanet.name;
                peopleList.Add(person);
            }

            return peopleList;
        }
    }
}