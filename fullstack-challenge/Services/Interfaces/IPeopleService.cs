using System.Collections.Generic;
using System.Threading.Tasks;
using fullstack_challenge.Entities;

namespace fullstack_challenge.Services.Interfaces{
    public interface IPeopleService
    {
        Task<List<Person>> GetPeople(int pageNumber);
    }
}