using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class PosterItem
    {
        public string Url
        {
            get { return url; }
        }

        [DataMember]
        private string url;
    }
}