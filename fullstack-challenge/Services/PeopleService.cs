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

        public async Task<List<Person>> GetPeople(int pageNumber){
            var response = await GetPeopleFromSwapi(pageNumber);
            var personList = TransformSwapiPeopleToPersonList(response);
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

        private List<Person> TransformSwapiPeopleToPersonList(string swapiPeopleResult){
            var deserializedSwapiPeopleResponse = DeserializeSwapiPeopleResponse(swapiPeopleResult);

            var peopleList = new List<Person>();
            foreach (var swapiPerson in deserializedSwapiPeopleResponse.results){
                var person = Mapper.Map<Person>(swapiPerson);
                peopleList.Add(person);
            }

            return peopleList;
        }

        private SwapiPeopleResponse DeserializeSwapiPeopleResponse(string SwapiResponse){
            SwapiPeopleResponse deserializedSwapiPeopleResponse = new SwapiPeopleResponse();  
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(SwapiResponse));  
            DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedSwapiPeopleResponse.GetType());  
            deserializedSwapiPeopleResponse = ser.ReadObject(ms) as SwapiPeopleResponse;  
            ms.Close();  
            return deserializedSwapiPeopleResponse;
        }
    }
}