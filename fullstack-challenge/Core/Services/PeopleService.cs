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

namespace Core.Services
{
    public class PeopleService : IPeopleService
    {

        string swapiUrl = "https://swapi.co/api/";
        private static readonly HttpClient client = new HttpClient();
        private readonly IPlanetService planetService;
        private IMapper mapper;

        public PeopleService(IPlanetService planetService, IMapper mapper)
        {
            this.planetService = planetService;
            this.mapper = mapper;
        }

        public async Task<List<Person>> GetAllPeople(int pageNumber)
        {
            var response = await GetAllPeopleFromSwapi(pageNumber);
            var personList = await TransformSwapiPeopleToPersonList(response);
            return personList;
        }

        private async Task<string> GetAllPeopleFromSwapi(int pageNumber)
        {
            string requestUrl = $"{swapiUrl}people/?page={pageNumber}";
            if (pageNumber == 0)
            {
                requestUrl = $"{swapiUrl}people/";
            }
            var response = await client.GetStringAsync(requestUrl);
            return response;
        }

        private async Task<List<Person>> TransformSwapiPeopleToPersonList(string swapiPeopleResult)
        {
            var deserializedSwapiPeopleResponse = JsonConvert.DeserializeObject<SwapiPeopleResponse>(swapiPeopleResult);

            var peopleList = new List<Person>();
            if (deserializedSwapiPeopleResponse.results != null)
            {
                foreach (var swapiPerson in deserializedSwapiPeopleResponse.results)
                {
                    var person = await CompletePersonInfo(swapiPerson);
                    peopleList.Add(person);
                }
            }

            return peopleList;
        }

        private async Task<Person> CompletePersonInfo(SwapiPerson swapiPerson)
        {
            var person = mapper.Map<SwapiPerson, Person>(swapiPerson);
            person.Homeworld = await GetPlanetName(person.Homeworld);
            return person;
        }

        private async Task<string> GetPlanetName(string planetUrl)
        {
            var swapiPlanet = await planetService.GetPlanet(planetUrl);
            return swapiPlanet.name;
        }

        public async Task<SwapiPerson> GetPersonByUrl(string personUrl)
        {
            var response = await client.GetStringAsync(personUrl);
            var person = JsonConvert.DeserializeObject<SwapiPerson>(response);
            return person;
        }
    }
}