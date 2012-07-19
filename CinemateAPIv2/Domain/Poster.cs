using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class Poster
    {
        public PosterItem Small
        {
            get { return small; }
        }

        public PosterItem Medium
        {
            get { return medium; }
        }

        public PosterItem Big
        {
            get { return big; }
        }

        [DataMember]
        private PosterItem small;

        [DataMember]
        private PosterItem medium;

        [DataMember]
        private PosterItem big;
    }
}