using System;
using System.Xml.Serialization;

namespace CinemateAPI
{
	[Serializable]
	public class CinemateCountry
	{
		[XmlElement("name")]
		public string Name { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}