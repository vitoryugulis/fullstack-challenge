using System;
using System.Collections.Generic;

namespace fullstack_challenge.Services{
    public class Results
    {
        public string name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }
        public List<string> films { get; set; }
        public List<string> species { get; set; }
        public List<object> vehicles { get; set; }
        public List<object> starships { get; set; }
        public string created { get; set; }
        public string edited { get; set; }
        public string url { get; set; }
    }

    public class SwapiPeople
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Results> results { get; set; }
    }
}
