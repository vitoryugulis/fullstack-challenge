using System.Collections.Generic;
using Core.Entities;

namespace Core.Services.Models
{
    public class PaginatedSpecies
    {
        public int TotalResults { get; set; }
        public List<Species> Species { get; set; }
    }
}