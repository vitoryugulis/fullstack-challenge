using System.Collections.Generic;

namespace Core.Services.Models
{
    public class SwapiSpecies
    {
        public string name { get; set; }
        public string classification { get; set; }
        public string designation { get; set; }
        public string average_height { get; set; }
        public string skin_colors { get; set; }
        public string hair_colors { get; set; }
        public string eye_colors { get; set; }
        public string average_lifespan { get; set; }
        public string homeworld { get; set; }
        public string language { get; set; }
        public List<string> people { get; set; }
        public List<string> films { get; set; }
        public string created { get; set; }
        public string edited { get; set; }
        public string url { get; set; }
    }

    public class SwapiSpeciesResponse
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<SwapiSpecies> results { get; set; }
    }
}