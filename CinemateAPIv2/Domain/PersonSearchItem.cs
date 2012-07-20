using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class PersonSearchItem
    {
        public string Url
        {
            get { return url; }
        }

        public string Name
        {
            get { return name; }
        }

        public string OriginalName
        {
            get { return nameOriginal; }
        }

        public long Id
        {
            get { return id; }
        }

        public Photo Photo
        {
            get { return photo; }
        }

        [DataMember]
        private string url;

        [DataMember]
        private string name;

        [DataMember(Name = "name_original")]
        private string nameOriginal;

        [DataMember]
        private long id;

        [DataMember]
        private Photo photo;

        public override string ToString()
        {
            return Name;
        }
    }
}