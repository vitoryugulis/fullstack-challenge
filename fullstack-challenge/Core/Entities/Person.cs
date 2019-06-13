using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Core.Entities
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Homeworld { get; set; }
    }
}