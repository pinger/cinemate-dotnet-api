using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class PersonSearchResult
    {
        public int TotalFound
        {
            get { return totalFound; }
        }

        public PersonSearchItem[] Persons
        {
            get { return persons; }
        }

        [DataMember(Name = "total_found")]
        private int totalFound;

        [DataMember(Name = "person")]
        private PersonSearchItem[] persons;
    }
}