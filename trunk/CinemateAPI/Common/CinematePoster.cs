using System;
using System.Xml.Serialization;

namespace CinemateAPI.Common
{
	[Serializable]
	public class CinematePoster
	{
		[XmlElement("small")] 
		public Link Small;

		[XmlElement("medium")] 
		public Link Medium;

		[XmlElement("big")] 
		public Link Big;
	}
}