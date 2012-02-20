using System;
using System.Xml.Serialization;

namespace CinemateAPI.Common
{
	[Serializable]
	public class Link
	{
		[XmlAttribute("url")]
		public string Url { get; set; }
	}
}