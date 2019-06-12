using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Services.Models;
using Newtonsoft.Json;

namespace Core.Services
{
    public class SpeciesService : ISpeciesService
    {

        string swapiUrl = "https://swapi.co/api/";
        private static readonly HttpClient client = new HttpClient();
        private IPeopleService peopleService;
        private readonly IPlanetService planetService;
        private IMapper mapper;

        public SpeciesService(IPeopleService peopleService, IPlanetService planetService, IMapper mapper)
        {
            this.peopleService = peopleService;
            this.planetService = planetService;
            this.mapper = mapper;
        }

        public async Task<SwapiSpecies> GetSpeciesByUrl(string speciesUrl)
        {
            var response = await client.GetStringAsync(speciesUrl);
            var swapiSpecies = JsonConvert.DeserializeObject<SwapiSpecies>(response);
            return swapiSpecies;
        }

        public async Task<List<Species>> GetAllSpecies(int pageNumber)
        {
            var swapiSpeciesResponse = await GetAllSpeciesFromSwapi(pageNumber);
            var speciesList = new List<Species>();
            foreach (var swapiSpecies in swapiSpeciesResponse.results)
            {
                var species = await GetSpeciesFullInfo(swapiSpecies);
                speciesList.Add(species);
            }
            return speciesList;
        }

        private async Task<SwapiSpeciesResponse> GetAllSpeciesFromSwapi(int pageNumber)
        {
            string requestUrl = $"{swapiUrl}species/?page={pageNumber}";
            if (pageNumber == 0)
            {
                requestUrl = $"{swapiUrl}species/";
            }
            var response = await client.GetStringAsync(requestUrl);

            var swapiSpeciesResponse = JsonConvert.DeserializeObject<SwapiSpeciesResponse>(response);
            return swapiSpeciesResponse;
        }

        private async Task<Species> GetSpeciesFullInfo(SwapiSpecies swapiSpecies)
        {
            var species = mapper.Map<SwapiSpecies, Species>(swapiSpecies);
            species.Persons = new List<Person>();
            species.Homeworld = await GetPlanetName(swapiSpecies.homeworld);
            foreach (var personUrl in swapiSpecies.people)
            {
                var person = await GetPersonFullInfo(personUrl);
                species.Persons.Add(person);
            }
            return species;
        }

        private async Task<Person> GetPersonFullInfo(string personUrl)
        {
            var swapiPerson = await peopleService.GetPersonByUrl(personUrl);
            var person = mapper.Map<SwapiPerson, Person>(swapiPerson);
            person.Homeworld = await GetPlanetName(swapiPerson.homeworld);
            return person;
        }

        private async Task<string> GetPlanetName(string planetUrl)
        {
            var swapiPlanet = await planetService.GetPlanet(planetUrl);
            return swapiPlanet.name;
        }
    }
}