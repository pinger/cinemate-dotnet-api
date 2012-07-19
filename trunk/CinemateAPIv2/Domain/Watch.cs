using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class Watch
    {
        public WatchItem[] Comments
        {
            get { return comments; }
        }

        public WatchItem[] Movies
        {
            get { return movies; }
        }

        [DataMember(Name = "comment")]
        private WatchItem[] comments;

        [DataMember(Name = "movie")]
        private WatchItem[] movies;
    }
}
