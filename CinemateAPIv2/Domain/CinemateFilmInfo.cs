using System;
using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class CinemateFilmInfo : CinemateFilmItem
    {
        public DateTime ReleaseDateRussia
        {
            get { return releaseDateRussia; }
        }

        public DateTime ReleaseDateWorld
        {
            get { return releaseDateWorld; }
        }

        public DateTime Date
        {
            get { return date; }
        }

        public int Runtime
        {
            get { return runtime; }
        }

        public string Description
        {
            get { return description; }
        }

        public KinopoiskInfo Kinopoisk
        {
            get { return kinopoisk; }
        }

        public ImdbInfo Imdb
        {
            get { return imdb; }
        }

        [DataMember(Name = "release_date_russia")]
        private DateTime releaseDateRussia;

        [DataMember(Name = "release_date_world")]
        private DateTime releaseDateWorld;

        [DataMember]
        private DateTime date;

        [DataMember]
        private int runtime;

        [DataMember]
        private string description;

        [DataMember]
        private KinopoiskInfo kinopoisk;

        [DataMember]
        private ImdbInfo imdb;
    }
}