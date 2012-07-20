using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class PersonInfoResult
    {
        public PersonSearchItem Person
        {
            get { return person; }
        }

        [DataMember]
        private PersonSearchItem person;
    }
}