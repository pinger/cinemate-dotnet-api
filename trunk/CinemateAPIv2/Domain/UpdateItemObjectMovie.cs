using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class UpdateItemObjectMovie
    {
        public string Title
        {
            get { return title; }
        }

        public long Id
        {
            get { return id; }
        }

        [DataMember]
        private string title;

        [DataMember]
        private long id;
    }
}