using System;
using System.Xml.Serialization;

namespace CinemateAPI.Movie
{
	[Serializable]
	public class KinopoiskInfo
	{
		[XmlAttribute("rating")] 
		public float Rating;

		[XmlAttribute("votes")] 
		public int Votes;

		public override string ToString()
		{
			return string.Format("Rating: {0}, Votes: {1}", Rating, Votes);
		}
	}
}