using System.Collections.Generic;

namespace Core.Entities
{
    public class Species
    {
        public string Name { get; set; }
        public string Homeworld { get; set; }
        public List<Person> Persons { get; set; }
    }
}