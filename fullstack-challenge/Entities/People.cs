using System.Collections.Generic;
using System.Runtime.Serialization;

namespace fullstack_challenge.Entities{
    [DataContract]
    public class People{
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Homeworld { get; set; }
        [DataMember]
        public List<string> Species { get; set; }
    }
}