using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces{
    public interface IPeopleService
    {
        Task<List<Person>> GetPeople(int pageNumber);
    }
}