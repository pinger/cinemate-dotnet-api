﻿using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class ImdbInfo
    {
        public string Url
        {
            get { return url; }
        }

        public float Rating
        {
            get { return rating; }
        }

        public int Votes
        {
            get { return votes; }
        }

        [DataMember]
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