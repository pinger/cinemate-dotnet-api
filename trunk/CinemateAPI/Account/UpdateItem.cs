using System;
using System.Xml.Serialization;

namespace CinemateAPI.Account
{
	[Serializable, XmlType("update")]
	public class UpdateItem
	{
		/// <summary>
		/// дата и время добавления записи в ленту обновлений пользователя в ISO формате
		/// </summary>
		[XmlElement("date")]
		public DateTime Date;

		/// <summary>
		/// текстовое описание обновления
		/// </summary>
		[XmlElement("description")]
		public string Description;

		/// <summary>
		/// ссылка на обновление; переход по ссылке отмечает запись в ленте прочитанной и производит редирект на страницу с обновлением
		/// </summary>
		[XmlElement("url")]
		public string Url;

		/// <summary>
		/// флаг прочитанного обновления (1 - непрочтенное, 0 - прочтенное)
		/// </summary>
		[XmlElement("new")]
		public int New;

		/// <summary>
		/// список объектов object, к которым привязано обновление со следующими атрибутами:
		/// </summary>
		[XmlArray("for_object")]
		public UpdateItemObject[] Objects;
	}
}