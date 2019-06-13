using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Services.Models;

namespace Core.Interfaces{
    public interface IPeopleService
    {
        Task<List<Person>> GetAllPeople(int pageNumber);
        Task<SwapiPerson> GetPersonByUrl(string personUrl);
    }
}