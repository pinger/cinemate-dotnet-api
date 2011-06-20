using System;
using System.Xml.Serialization;
using CinemateAPI.Common;

namespace CinemateAPI.Person
{
	[Serializable, XmlType("person")]
	public class CinematePerson
	{
		/// <summary>
		/// русскоязычное имя персоны
		/// </summary>
		[XmlElement("name")] 
		public string Name;

		/// <summary>
		/// имя персоны в оригинале
		/// </summary>
		[XmlElement("name_original")]
		public string NameOriginal;

		/// <summary>
		/// включает в себя 3 тега со ссылками на фотографии разных размеров
		/// </summary>
		[XmlElement("photo")]
		public CinematePoster Photo;

		/// <summary>
		/// ссылка на страницу персоны
		/// </summary>
		[XmlElement("url")]
		public string Url;

		public override string ToString()
		{
			return Name;
		}
	}
}