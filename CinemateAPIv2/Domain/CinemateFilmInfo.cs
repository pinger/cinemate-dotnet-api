using System;
using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class CinemateFilmInfo : CinemateFilmItem
    {
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