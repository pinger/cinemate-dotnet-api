using System;
using System.Xml.Serialization;

namespace CinemateAPI.Account
{
    [Serializable]
    public class WatchlistItem
    {
        [XmlElement("type")]
        public WatchlistItemType Type;

        /// <summary>
        /// дата и время добавления объекта в список слежения в ISO формате
        /// </summary>
        [XmlElement("date")]
        public DateTime Date;

        /// <summary>
        /// строковое представление объекта слежения
        /// </summary>
        [XmlElement("name")]
        public string Name;

        /// <summary>
        /// описание подписки на объект
        /// </summary>
        [XmlElement("description")]
        public string Description;

        /// <summary>
        /// ссылка на объект слежения
        /// </summary>
        [XmlElement("url")]
        public string Url;

        public override string ToString()
        {
            switch (Type)
            {
                case WatchlistItemType.Comment:
                    return Name;
                case WatchlistItemType.Movie:
                    return string.Format("Раздача {0}", Name);
                case WatchlistItemType.Person:
                    return Name;
            }
            return base.ToString();
        }
    }
}