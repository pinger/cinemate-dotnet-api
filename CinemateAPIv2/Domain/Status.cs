using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class Stats
    {
        public int CountComments
        {
            get { return countComments; }
        }

        public int CountUsers
        {
            get { return countUsers; }
        }

        public int CountReviews
        {
            get { return countReviews; }
        }

        public int CountMovies
        {
            get { return countMovies; }
        }

        [DataMember(Name = "comment_count")]
        private int countComments;

        [DataMember(Name = "user_count")]
        private int countUsers;

        [DataMember(Name = "review_count")]
        private int countReviews;

        [DataMember(Name = "movie_count")]
        private int countMovies;
    }
}