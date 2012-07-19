using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class MovieListResult
    {
        public CinemateFilmItem[] Movies
        {
            get { return movies; }
        }

        [DataMember(Name = "movie")]
        private CinemateFilmItem[] movies;
    }
}