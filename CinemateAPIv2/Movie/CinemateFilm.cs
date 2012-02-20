using System;
using System.Xml.Serialization;
using CinemateAPI.Common;

namespace CinemateAPI.Movie
{
	[Serializable, XmlType("movie")]
	public class CinemateFilm
	{
		/// <summary>
		/// Дата и время появления фильма на сайте в ISO формате
		/// </summary>
		[XmlElement("date")] 
		public DateTime Date;

		/// <summary>
		/// русскоязычное название фильма
		/// </summary>
		[XmlElement("title_russian")] 
		public String TitleRussian;

		/// <summary>
		/// название фильма в оригинале
		/// </summary>
		[XmlElement("title_original")] 
		public String TitleOriginal;

		/// <summary>
		/// англоязычное название фильма
		/// </summary>
		[XmlElement("title_english")] 
		public String TitleEnglish;

		/// <summary>
		/// год выхода фильма
		/// </summary>
		[XmlElement("year")] 
		public int Year;

		/// <summary>
		/// включает в себя 3 тега со ссылками на постеры разных размеров
		/// </summary>
		[XmlElement("poster")] 
		public CinematePoster Poster;

		/// <summary>
		/// описание фильма
		/// </summary>
		[XmlElement("description")] 
		public String Description;

		/// <summary>
		/// длительность фильма в минутах
		/// </summary>
		[XmlElement("runtime")] 
		public int Runtime;

		/// <summary>
		/// дата выхода фильма в мире в ISO формате
		/// </summary>
		[XmlElement("release_date_world")] 
		public DateTime ReleaseDateWorld;

		/// <summary>
		/// дата выхода фильма в России в ISO формате
		/// </summary>
		[XmlElement("release_date_russia")] 
		public DateTime ReleaseDateRussia;

		/// <summary>
		/// дата выхода фильма в России в ISO формате
		/// </summary>
		[XmlElement("imdb")] 
		public ImdbInfo Imdb;

		/// <summary>
		/// рейтинг фильма по версии kinopoisk.ru
		/// </summary>
		[XmlElement("kinopoisk")]
		public KinopoiskInfo Kinopoisk;

		/// <summary>
		/// список стран-создателей фильма, представленный списком тегов name с русским названием стран
		/// </summary>
		[XmlArray("country")] 
		public string[] Countries;

		/// <summary>
		/// список жанров фильма, представленный списком тегов name с русским названием жанров
		/// </summary>
		[XmlArray("genre")] 
		public string[] Genres;

		/// <summary>
		/// список режиссеров фильма, представленный списком тегов name с русским именами режиссеров
		/// </summary>
		[XmlArray("director")] 
		public string[] Directors;

		/// <summary>
		/// список актеров фильма, представленный списком тегов name с русским именами актеров
		/// </summary>
		[XmlArray("cast")] 
		public string[] Actors;

		/// <summary>
		/// ссылка на страницу фильма
		/// </summary>
		[XmlElement("url")]
		public string Url;

		public override string ToString()
		{
			return string.Format("{0} ({1})", TitleOriginal, Year);
		}
	}
}