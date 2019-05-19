using System.Collections.Generic;
using System.Threading.Tasks;
using fullstack_challenge.Entities;

namespace fullstack_challenge.Services{
    public interface IPeopleService
    {
        Task<List<People>> GetPeople(int pageNumber);
    }
}