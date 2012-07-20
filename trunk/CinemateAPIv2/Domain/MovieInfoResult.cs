using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class MovieInfoResult
    {
        public CinemateFilmInfo Movie
        {
            get { return movie; }
        }

        [DataMember]
        private CinemateFilmInfo movie;
    }
}