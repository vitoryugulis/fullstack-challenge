using AutoMapper;
using fullstack_challenge.Entities;
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

        public async Task<List<People>> GetPeople(int pageNumber){
            var response = await GetPeopleFromSwapi(pageNumber);
            return response;
        }

        private async Task<List<People>> GetPeopleFromSwapi(int pageNumber){
            string requestUrl = $"{swapiUrl}people/?page={pageNumber}";
            if(pageNumber == 0){
                requestUrl = $"{swapiUrl}people/";
            }
            var response = await client.GetAsync(requestUrl);
            var result = await response.Content.ReadAsStringAsync();

            SwapiPeople deserializedSwapiPeople = new SwapiPeople();  
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(result));  
            DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedSwapiPeople.GetType());  
            deserializedSwapiPeople = ser.ReadObject(ms) as SwapiPeople;  
            ms.Close();  

            var peopleList = new List<People>();
            foreach (var pp in deserializedSwapiPeople.results){
                var people = Mapper.Map<People>(pp);
                peopleList.Add(people);
            }

            return peopleList;
        }
    }
}