using System;
using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class WatchItem
    {
        public DateTime Date
        {
            get { return date; }
        }

        public string Url
        {
            get { return url; }
        }

        public string Description
        {
            get { return description; }
        }

        public long Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public override string ToString()
        {
            return Name;
        }

        [DataMember]
        private DateTime date;

        [DataMember]
        private string url;

        [DataMember]
        private string description;

        [DataMember]
        private long id;

        [DataMember]
        private string name;
    }
}
