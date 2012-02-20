using System;
using System.Xml.Serialization;

namespace CinemateAPI.Account
{
	[Serializable, XmlType("object")]
	public class UpdateItemObject
	{
		/// <summary>
		/// строковое представление объекта
		/// </summary>
		[XmlAttribute("title")]
		public string Title;

		/// <summary>
		/// ссылка на объект обновления
		/// </summary>
		[XmlAttribute("url")]
		public string Url;
	}
}