using System;
using System.Xml.Serialization;

namespace CinemateAPI.Stat
{
	[Serializable]
	public class Statistic
	{
		/// <summary>
		/// число новых пользователей на сайте за последние сутки
		/// </summary>
		[XmlElement("users_count")]
		public int UsersCount;

		/// <summary>
		/// число новых отзывов на сайте за последние сутки
		/// </summary>
		[XmlElement("reviews_count")]
		public int ReviewsCount;

		/// <summary>
		/// число новых комментариев к отзывам на сайте за последние сутки
		/// </summary>
		[XmlElement("comments_count")]
		public int CommentsCount;

		/// <summary>
		/// число новых фильмов на сайте за последние сутки
		/// </summary>
		[XmlElement("movies_count")]
		public int MoviesCount;
	}
}