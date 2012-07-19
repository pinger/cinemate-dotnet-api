using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class KinopoiskInfo
    {
        public string Url
        {
            get { return url; }
        }

        public int Votes
        {
            get { return votes; }
        }

        public float Rating
        {
            get { return rating; }
        }

        [DataMember(Name = "kinopoisk")]
        private string url;

        [DataMember]
        private float rating;

        [DataMember]
        private int votes;

        public override string ToString()
        {
            return string.Format("Rating: {0}, Votes: {1}", Rating, Votes);
        }
    }
}