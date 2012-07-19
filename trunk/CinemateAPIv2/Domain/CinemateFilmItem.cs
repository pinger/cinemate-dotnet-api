using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class CinemateFilmItem
    {
        public string Url
        {
            get { return url; }
        }

        public string TitleEnglish
        {
            get { return titleEnglish; }
        }

        public string TitleOriginal
        {
            get { return titleOriginal; }
        }

        public string TitleRussian
        {
            get { return titleRussian; }
        }

        public int Year
        {
            get { return year; }
        }

        public long Id
        {
            get { return id; }
        }

        public string Trailer
        {
            get { return trailer; }
        }

        public Poster Poster
        {
            get { return poster; }
        }

        [DataMember]
        private string url;

        [DataMember(Name = "title_english")]
        private string titleEnglish;

        [DataMember(Name = "title_original")]
        private string titleOriginal;

        [DataMember(Name = "title_russian")]
        private string titleRussian;

        [DataMember]
        private int year;

        [DataMember]
        private long id;

        [DataMember]
        private string trailer;

        [DataMember]
        private Poster poster;
    }
}